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

        private void beforeThirtyMin_Clicked(object sender, EventArgs e)
        {
            DateTime pushTime;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("ja-JP");
            if (DateTime.TryParse("2017/" + item.Start, culture, DateTimeStyles.None, out pushTime))
            {
                pushTimeMillis = (long)pushTime.AddMinutes(-30).ToUniversalTime().Subtract(new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                pushMessage = "あと30分で企画の開始時間です";
                if (Application.Current.Properties.ContainsKey(item.Id + ":30"))
                {
                    DependencyService.Get<IToast>().Show("すでに通知が設定されています");
                }
                else
                {
                    MessagingCenter.Send(this, "NOTIFY");
                    Application.Current.Properties[item.Id + ":30"] = true;
                    DependencyService.Get<IToast>().Show(pushTitle + "の開始30分前に通知が設定されました", true);
                    Navigation.PopAsync();
                }
            }
            else
            {
                DependencyService.Get<IToast>().Show("常設企画やゲリラ企画は通知を設定できません", true);
                Navigation.PopAsync();
            }
        }

        private void beforeAnHour_Clicked(object sender, EventArgs e)
        {
            DateTime pushTime;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("ja-JP");
            if (DateTime.TryParse("2017/" + item.Start, culture, DateTimeStyles.None, out pushTime))
            {
                pushTimeMillis = (long)pushTime.AddHours(-1).ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                pushMessage = "あと１時間で企画の開始時間です";
                if (Application.Current.Properties.ContainsKey(item.Id + ":60"))
                {
                    DependencyService.Get<IToast>().Show("すでに通知が設定されています");
                }
                else
                {
                    MessagingCenter.Send(this, "NOTIFY");
                    Application.Current.Properties[item.Id + ":60"] = true;
                    DependencyService.Get<IToast>().Show(pushTitle + "の開始1時間前に通知が設定されました", true);
                    Navigation.PopAsync();
                }
            }
            else
            {
                DependencyService.Get<IToast>().Show("常設企画やゲリラ企画は通知を設定できません", true);
                Navigation.PopAsync();
            }
        }

        private void beforeDay_Clicked(object sender, EventArgs e)
        {
            DateTime pushTime;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("ja-JP");
            if (DateTime.TryParse("2017/" + item.Start, culture, DateTimeStyles.None, out pushTime))
            {
                pushTimeMillis = (long)pushTime.AddHours(-24).ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                pushMessage = "明日" + item.Start + "から企画が始まります";
                if (Application.Current.Properties.ContainsKey(item.Id + ":24"))
                {
                    DependencyService.Get<IToast>().Show("すでに通知が設定されています");
                }
                else
                {
                    MessagingCenter.Send(this, "NOTIFY");
                    Application.Current.Properties[item.Id + ":24"] = true;
                    DependencyService.Get<IToast>().Show(pushTitle + "の開始一日前に通知が設定されました", true);
                    Navigation.PopAsync();
                }
            }
            else
            {
                DependencyService.Get<IToast>().Show("常設企画やゲリラ企画は通知を設定できません", true);
                Navigation.PopAsync();
            }
        }

        private void beforeTwoHour_Clicked(object sender, EventArgs e)
        {
            DateTime pushTime;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("ja-JP");
            if (DateTime.TryParse("2017/" + item.Start, culture, DateTimeStyles.None, out pushTime))
            {
                pushTimeMillis = (long)pushTime.AddHours(-2).ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                pushMessage = "あと２時間で企画の開始時間です";
                if (Application.Current.Properties.ContainsKey(item.Id + ":120"))
                {
                    DependencyService.Get<IToast>().Show("すでに通知が設定されています");
                }
                else
                {
                    MessagingCenter.Send(this, "NOTIFY");
                    Application.Current.Properties[item.Id + ":120"] = true;
                    DependencyService.Get<IToast>().Show(pushTitle + "の開始2時間前に通知が設定されました", true);
                    Navigation.PopAsync();
                }
            }
            else
            {
                DependencyService.Get<IToast>().Show("常設企画やゲリラ企画は通知を設定できません", true);
                Navigation.PopAsync();
            }
        }

        private void beforeThreeHour_Clicked(object sender, EventArgs e)
        {
            DateTime pushTime;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("ja-JP");
            if (DateTime.TryParse("2017/" + item.Start, culture, DateTimeStyles.None, out pushTime))
            {
                pushTimeMillis = (long)pushTime.AddHours(-3).ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                pushMessage = "あと3時間で企画の開始時間です";
                if (Application.Current.Properties.ContainsKey(item.Id + ":180"))
                {
                    DependencyService.Get<IToast>().Show("すでに通知が設定されています");
                }
                else
                {
                    MessagingCenter.Send(this, "NOTIFY");
                    Application.Current.Properties[item.Id + ":180"] = true;
                    DependencyService.Get<IToast>().Show(pushTitle + "の開始3時間前に通知が設定されました", true);
                    Navigation.PopAsync();
                }
            }
            else
            {
                DependencyService.Get<IToast>().Show("常設企画やゲリラ企画は通知を設定できません", true);
                Navigation.PopAsync();
            }
        }
    }
}