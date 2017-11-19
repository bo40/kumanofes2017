using Kumanofes2017.Helpers;
using Kumanofes2017.Models;
using Kumanofes2017.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kumanofes2017.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public InfoDataStore DataStore = new InfoDataStore();
        public ObservableRangeCollection<InfoItem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public AboutViewModel()
        {
            Title = "熊野寮祭2017";

            Items = new ObservableRangeCollection<InfoItem>();

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://kumano-dormitory.github.io/ryosai/")));

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        /// <summary>
        /// Command to open browser to xamarin.com
        /// </summary>
        public ICommand OpenWebCommand { get; }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync();
                Items.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
