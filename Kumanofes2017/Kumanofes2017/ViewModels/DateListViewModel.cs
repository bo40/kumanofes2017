using System;
using System.Collections.Generic;
using System.Text;

using Kumanofes2017.Helpers;
using Kumanofes2017.Models;
using Kumanofes2017.Views;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Diagnostics;
using Kumanofes2017.Services;

namespace Kumanofes2017.ViewModels
{
    public class DateListViewModel : BaseViewModel
    {
        public IDataStore<DateItem> DataStore => DependencyService.Get<IDataStore<DateItem>>();
        public ObservableRangeCollection<DateItem> DateList { get; set; }
        public Command LoadItemsCommand { get; set; }

        public DateListViewModel()
        {
            Title = "企画日時一覧";
            DateList = new ObservableRangeCollection<DateItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                DateList.Clear();
                var items = await DataStore.GetItemsAsync("", true);
                DateList.ReplaceRange(items);
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
