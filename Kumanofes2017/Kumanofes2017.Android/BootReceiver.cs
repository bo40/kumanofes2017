using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Android.Support.V4.App;
using Newtonsoft.Json;


namespace Kumanofes2017.Droid
{
    [BroadcastReceiver]
    [IntentFilter(new[] { Intent.ActionBootCompleted }, Priority = (int)IntentFilterPriority.LowPriority)]
    public class BootReceiver : BroadcastReceiver
    {
        readonly int REQUEST_CODE = 5257; // Intent送信リクエストのID

        public override void OnReceive(Context context, Intent intent)
        {
            //リマインダーをセット
            this.SetReminder(context);
        }

        //Android用のリマインダー
        public void SetReminder(Context context)
        {

            string str = (string)Xamarin.Forms.Application.Current.Properties["notifications"];
            List<string> notify_list = JsonConvert.DeserializeObject<List<string>>(str);
            foreach(var id in notify_list)
            {
                var notification = JsonConvert.DeserializeObject<Kumanofes2017.Models.Notification>((string)Xamarin.Forms.Application.Current.Properties[id]);
                // for debug
                // Xamarin.Forms.Application.Current.Properties[id] = "";
                // ------
                if (notification.ThirtyMinPush != 0)
                {
                    DateTime pushTime;
                    System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CreateSpecificCulture("ja-JP");
                    DateTime.TryParse("2017/" + "11/28 17:58", culture, System.Globalization.DateTimeStyles.None, out pushTime);
                    long pushTimeMillis = (long)pushTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

                    Intent alarmIntent = new Intent(context, typeof(AlarmReceiver));
                    alarmIntent.PutExtra("id", id);
                    alarmIntent.PutExtra("jsonItem", notification.jsonItem);
                    alarmIntent.PutExtra("title", notification.title);
                    alarmIntent.PutExtra("message", notification.message);
                    PendingIntent pendingIntent = PendingIntent.GetBroadcast(context, REQUEST_CODE, alarmIntent, PendingIntentFlags.UpdateCurrent);

                    AlarmManager alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);

                    alarmManager.SetExact(AlarmType.RtcWakeup, pushTimeMillis, pendingIntent);
                }
                if (notification.AnHourPush != 0)
                {
                    Intent alarmIntent = new Intent(context, typeof(AlarmReceiver));
                    alarmIntent.PutExtra("id", id);
                    alarmIntent.PutExtra("jsonItem", notification.jsonItem);
                    alarmIntent.PutExtra("title", notification.title);
                    alarmIntent.PutExtra("message", notification.message);
                    PendingIntent pendingIntent = PendingIntent.GetBroadcast(context, REQUEST_CODE, alarmIntent, PendingIntentFlags.UpdateCurrent);
                    AlarmManager alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);
                    alarmManager.SetExact(AlarmType.RtcWakeup, notification.AnHourPush, pendingIntent);
                }
                if (notification.TwoHoursPush != 0)
                {
                    Intent alarmIntent = new Intent(context, typeof(AlarmReceiver));
                    alarmIntent.PutExtra("id", id);
                    alarmIntent.PutExtra("jsonItem", notification.jsonItem);
                    alarmIntent.PutExtra("title", notification.title);
                    alarmIntent.PutExtra("message", notification.message);
                    PendingIntent pendingIntent = PendingIntent.GetBroadcast(context, REQUEST_CODE, alarmIntent, PendingIntentFlags.UpdateCurrent);
                    AlarmManager alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);
                    alarmManager.SetExact(AlarmType.RtcWakeup, notification.TwoHoursPush, pendingIntent);
                }
                if (notification.ThreeHoursPush != 0)
                {
                    Intent alarmIntent = new Intent(context, typeof(AlarmReceiver));
                    alarmIntent.PutExtra("id", id);
                    alarmIntent.PutExtra("jsonItem", notification.jsonItem);
                    alarmIntent.PutExtra("title", notification.title);
                    alarmIntent.PutExtra("message", notification.message);
                    PendingIntent pendingIntent = PendingIntent.GetBroadcast(context, REQUEST_CODE, alarmIntent, PendingIntentFlags.UpdateCurrent);
                    AlarmManager alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);
                    alarmManager.SetExact(AlarmType.RtcWakeup, notification.ThreeHoursPush, pendingIntent);
                }
                if (notification.ADayPush != 0)
                {
                    Intent alarmIntent = new Intent(context, typeof(AlarmReceiver));
                    alarmIntent.PutExtra("id", id);
                    alarmIntent.PutExtra("jsonItem", notification.jsonItem);
                    alarmIntent.PutExtra("title", notification.title);
                    alarmIntent.PutExtra("message", notification.message);
                    PendingIntent pendingIntent = PendingIntent.GetBroadcast(context, REQUEST_CODE, alarmIntent, PendingIntentFlags.UpdateCurrent);
                    AlarmManager alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);
                    alarmManager.SetExact(AlarmType.RtcWakeup, notification.ADayPush, pendingIntent);
                }
            }
        }
    }
}