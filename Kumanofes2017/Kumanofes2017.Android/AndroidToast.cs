using Android.Widget;
using Kumanofes2017.Droid;
using Kumanofes2017.Services;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidToast))]
namespace Kumanofes2017.Droid
{
    class AndroidToast : IToast
    {
        public void Show(string message, bool isLong = false)
        {
            if (isLong)
            {
                Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
            }
        }
    }
}