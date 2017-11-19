using Kumanofes2017.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Kumanofes2017
{
	public partial class App : Application
	{
        public App()
		{
			InitializeComponent();

			SetMainPage();
		}

		public static void SetMainPage()
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
                    new NavigationPage(new DateListPage())
                    {
                        Title = "通常企画",
                        Icon = Device.OnPlatform<string>("tab_about.png",null,null)
                    },
                    new NavigationPage(new PermaGuerrillaPage())
                    {
                        Title = "常設・ゲリラ企画",
                        Icon = Device.OnPlatform<string>("tab_feed.png",null,null)
                    },
                }
            };
        }
	}
}
