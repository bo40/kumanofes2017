using Kumanofes2017.Models;
using Kumanofes2017.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kumanofes2017.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AlarmSetPage : ContentPage
	{
        public string Id { get; }
        public string pushItem { get; }
        public long pushTimeMillis { get; set; }
        public string pushTitle { get; }
        public string pushMessage { get; set; }
        Item item;

        public AlarmSetPage ()
		{
			InitializeComponent ();
		}

        public AlarmSetPage (Item item)
        {
            InitializeComponent();

            Caption.Text = item.Text;
            CaptionTime.Text = item.StartWithCaption;

            this.item = item;
            Id = item.Id;
            pushItem = JsonConvert.SerializeObject(item);
            pushTitle = item.Text;
            pushMessage = "";
        }

        public void SetNotification(int min)
        {
            DateTime pushTime;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("ja-JP");
            if (DateTime.TryParse("2017/" + /*"11/28 17:35"*/ item.Start, culture, DateTimeStyles.None, out pushTime))
            {
                pushTimeMillis = (long)pushTime.AddMinutes(-min).ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                pushMessage = "もうすぐ企画の開始時間です";
                if (Application.Current.Properties.ContainsKey(item.Id))
                {
                    string json = (string)Application.Current.Properties[item.Id];
                    // for debug
                    if (json.Equals(""))
                    {
                        ShowToast(1);
                        return;
                    }
                    // -----------
                    Notification notification = JsonConvert.DeserializeObject<Notification>(json);
                    if (notification.GetPushTime(min) != 0)
                    {
                        DependencyService.Get<IToast>().Show("すでに通知が設定されています");
                        return;
                    }
                    MessagingCenter.Send(this, "NOTIFY");
                    notification.SetPushTime(min, pushTimeMillis);
                    notification.jsonItem = this.pushItem;
                    notification.title = this.pushTitle;
                    notification.message = this.pushMessage;
                    Application.Current.Properties[item.Id] = JsonConvert.SerializeObject(notification);
                    ShowToast(min);
                }
                else
                {
                    Notification notification = new Notification(item.Id, min, pushTimeMillis);
                    notification.SetPushTime(min, pushTimeMillis);
                    notification.jsonItem = this.pushItem;
                    notification.title = this.pushTitle;
                    notification.message = this.pushMessage;
                    MessagingCenter.Send(this, "NOTIFY");
                    Application.Current.Properties[item.Id] = JsonConvert.SerializeObject(notification);
                    List<string> notify_list = JsonConvert.DeserializeObject<List<string>>((string)Application.Current.Properties["notifications"]);
                    notify_list.Add(item.Id);
                    Application.Current.Properties["notifications"] = JsonConvert.SerializeObject(notify_list);
                    ShowToast(min);
                }
                Navigation.PopAsync();
            }
            else
            {
                DependencyService.Get<IToast>().Show("常設企画やゲリラ企画は通知を設定できません", true);
                Navigation.PopAsync();
            }
        }

        private void beforeThirtyMin_Clicked(object sender, EventArgs e)
        {
            SetNotification(30);
        }

        private void beforeAnHour_Clicked(object sender, EventArgs e)
        {
            SetNotification(60);
        }

        private void beforeDay_Clicked(object sender, EventArgs e)
        {
            SetNotification(1440);
        }

        private void beforeTwoHour_Clicked(object sender, EventArgs e)
        {
            SetNotification(120);
        }

        private void beforeThreeHour_Clicked(object sender, EventArgs e)
        {
            SetNotification(180);
        }

        private void ShowToast(int min)
        {
            switch (min)
            {
                case 30:
                    DependencyService.Get<IToast>().Show(pushTitle + "の開始30分前に通知が設定されました", true);
                    break;
                case 60:
                    DependencyService.Get<IToast>().Show(pushTitle + "の開始1時間前に通知が設定されました", true);
                    break;
                case 120:
                    DependencyService.Get<IToast>().Show(pushTitle + "の開始2時間前に通知が設定されました", true);
                    break;
                case 180:
                    DependencyService.Get<IToast>().Show(pushTitle + "の開始3時間前に通知が設定されました", true);
                    break;
                case 1440:
                    DependencyService.Get<IToast>().Show(pushTitle + "の開始一日前に通知が設定されました", true);
                    break;
                default:
                    DependencyService.Get<IToast>().Show("なにやら変なことが起きました。バグなので報告してください", true);
                    break;
            }
        }
    }
}