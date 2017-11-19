using System;
using System.Diagnostics;
using System.Threading.Tasks;

using Kumanofes2017.Helpers;
using Kumanofes2017.Models;
using Kumanofes2017.Views;

using Xamarin.Forms;

namespace Kumanofes2017.ViewModels
{
	public class ItemsViewModel : BaseViewModel
	{
		public ObservableRangeCollection<Item> Items { get; set; }
		public Command LoadItemsCommand { get; set; }

		public ItemsViewModel(DateItem date = null)
		{
            Title = "Browse";
            if (date != null)
            {
                if (date.Id == "permanent")
                {
                    Title = "常設企画の一覧";
                }
                else if (date.Id == "guerrilla")
                {
                    Title = "ゲリラ企画の一覧";
                }
                else
                {
                    Title = date.Description + "の企画";
                }
            }
            Items = new ObservableRangeCollection<Item>();

            string arg = (date == null) ? "" : date.Id;
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(arg));
		}

		async Task ExecuteLoadItemsCommand(string dateId)
		{
			if (IsBusy)
				return;

			IsBusy = true;

			try
			{
				Items.Clear();
				var items = await DataStore.GetItemsAsync(dateId, true);
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