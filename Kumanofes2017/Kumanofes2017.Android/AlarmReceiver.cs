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
using Android.Support.V4.App;

namespace Kumanofes2017.Droid
{
    [BroadcastReceiver]
    public class AlarmReceiver : BroadcastReceiver
    {
        readonly int NOTIFICATION_ID = 9457; // 通知に付与するID
        readonly int REQUEST_CODE = 5257; // Intent送信リクエストのID

        public override void OnReceive(Context context, Intent intent)
        {
            var id = intent.GetStringExtra("id");
            var jsonItem = intent.GetStringExtra("jsonItem");
            var message = intent.GetStringExtra("message");
            var title = intent.GetStringExtra("title");

            var builder = new NotificationCompat.Builder(context);
            builder.SetSmallIcon(Resource.Drawable.icon);
            builder.SetContentTitle(title);
            builder.SetContentText(message);

            // 通知をタップした時に呼び出すIntent
            var resultIntent = new Intent(context, typeof(MainActivity));
            resultIntent.SetData(Android.Net.Uri.Parse(jsonItem));
            // resultIntent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTask);
            /*
            var pending = PendingIntent.GetActivity(context, 0,
            resultIntent,
            PendingIntentFlags.CancelCurrent);
            builder.SetContentIntent(pending);
            */

            // SingleTop が超重要で、これを付けないと、通知をタップした時
            // もうひとつ画面が起動してしまう。
            resultIntent.SetFlags(ActivityFlags.SingleTop | ActivityFlags.NewTask | ActivityFlags.ClearTask);

            builder.SetAutoCancel(true); // タップしたら通知は消すよ

            var contentIntent = PendingIntent.GetActivity(
                context, REQUEST_CODE + int.Parse(id), resultIntent, PendingIntentFlags.UpdateCurrent);
            builder.SetContentIntent(contentIntent);

            var manager = NotificationManagerCompat.From(context);
            manager.Notify(NOTIFICATION_ID, builder.Build());
        }
    }
}
 