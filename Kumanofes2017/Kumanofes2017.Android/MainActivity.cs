using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Android.Support.V4.App;
using Kumanofes2017.Views;
using Kumanofes2017.ViewModels;
using Kumanofes2017.Models;

namespace Kumanofes2017.Droid
{
    [Activity(Label = "熊野寮祭2017", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        App _app;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            // code for local push

            var startUpParam = string.Empty;

            // 画面が破棄された状態で通知をタップした場合、
            // ここで通知からのデータを取り出す。
            var intent = this.Intent;
            if (intent != null)
            {
                startUpParam = intent?.Data?.ToString() ?? string.Empty;
            }

            global::Xamarin.Forms.Forms.Init(this, bundle);

            // 通知から起動されたなら、 startUpParam は何か入っている
            _app = new App(startUpParam);
            LoadApplication(_app);

            // 通知を表示するメッセージを受信
            MessagingCenter.Subscribe<ItemDetailPage>(this, "NOTIFY", sender =>
            {
                var alarmIntent = new Intent(this, typeof(AlarmReceiver));
                alarmIntent.PutExtra("jsonItem", sender.pushItem);
                alarmIntent.PutExtra("title", sender.pushTitle);
                alarmIntent.PutExtra("message", sender.pushMessage);

                var pending = PendingIntent.GetBroadcast(this, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);

                var alarmManager = GetSystemService(AlarmService).JavaCast<AlarmManager>();
                alarmManager.Set(AlarmType.ElapsedRealtime, SystemClock.ElapsedRealtime() + 5 * 1000, pending);
            });
        }

        // SingleTop で且つ、画面が表示されている状態で通知をタップすると、
        // 送信されたIntentはここで受信する。
        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            // Android.Util.Log.Debug("Main", $"OnNewIntent");

            if (intent?.Data != null)
            {
                var uri = intent.Data;

                // ここに来たということは、Formsの画面は表示中なはずなので、
                // 現在表示されている Page の Navigation をどうにかして得て、
                // PushAsync などができる
                _app.SwitchToDateList();
                _app.DateListCurrentPage.Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel()));
            }
        }
    }
}