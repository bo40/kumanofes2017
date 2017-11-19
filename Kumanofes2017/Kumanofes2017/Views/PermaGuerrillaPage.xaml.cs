using Kumanofes2017.Models;
using Kumanofes2017.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kumanofes2017.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PermaGuerrillaPage : ContentPage
	{
        PermaGuerrillaViewModel viewModel;

		public PermaGuerrillaPage ()
		{
			InitializeComponent ();

            BindingContext = viewModel = new PermaGuerrillaViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as DateItem;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemsPage(new ItemsViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}