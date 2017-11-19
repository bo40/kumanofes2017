using Kumanofes2017.Helpers;
using Kumanofes2017.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kumanofes2017.ViewModels
{
    class PermaGuerrillaViewModel : BaseViewModel
    {
        public ObservableRangeCollection<DateItem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public PermaGuerrillaViewModel()
        {
            Title = "常設・ゲリラ企画";

            Items = new ObservableRangeCollection<DateItem>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            Items.Clear();
            Items.Add(new DateItem { Id = "permanent", Description = "常設企画" });
            Items.Add(new DateItem { Id = "guerrilla", Description = "ゲリラ企画" });
            IsBusy = false;
        }
    }
}
