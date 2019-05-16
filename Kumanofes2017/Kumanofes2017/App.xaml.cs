using Kumanofes2017.Models;
using Kumanofes2017.Services;
using Kumanofes2017.ViewModels;
using Kumanofes2017.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Kumanofes2017
{
	public partial class App : Application
	{
        NavigationPage dateListPage;
        public App(string startUpParam)
		{
			InitializeComponent();

            // 画面が破棄された状態で通知をタップすると startUpParam にデータが入ってくるので、
            // それを使って適宜なんとかする。
            // Prism.Forms を使っていれば URL ベースのナビゲーションが使えるのでいいかもね。

            dateListPage = new NavigationPage(new DateListPage())
            {
                Title = "企画一覧",
                Icon = Device.OnPlatform<string>("tab_about.png", null, null)
            };

            SetMainPage(dateListPage);

            if (!string.IsNullOrEmpty(startUpParam))
            {
                SwitchToDateList();
                Item item = JsonConvert.DeserializeObject<Item>(startUpParam);
                dateListPage.CurrentPage.Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
            }

            
            if (!Application.Current.Properties.ContainsKey("update7"))
            {
                DependencyService.Get<IToast>().Show("アプリケーションが更新されました。通知設定が初期化されたため、もう一度設定しなおす必要があります。");
                Application.Current.Properties["update7"] = "already";
            }
            

            if (!Application.Current.Properties.ContainsKey("notifications"))
            {
                Application.Current.Properties["notifications"] = JsonConvert.SerializeObject(new List<string>());
            }
        }

        public static void SetMainPage(NavigationPage dateListPage)
		{
            
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new AboutPage())
                    {
                        Title = "新着情報・周知",
                        Icon = Device.OnPlatform<string>("tab_about.png",null,null)
                    },
                    dateListPage,
                    /*
                    new NavigationPage(new PermaGuerrillaPage())
                    {
                        Title = "常設・ゲリラ企画",
                        Icon = Device.OnPlatform<string>("tab_feed.png",null,null)
                    },
                    */
                }
            };
        }

        public void SwitchToDateList()
        {

            ((TabbedPage)Current.MainPage).CurrentPage = dateListPage;
        }

        public Page DateListCurrentPage => dateListPage.CurrentPage;
    }
}
