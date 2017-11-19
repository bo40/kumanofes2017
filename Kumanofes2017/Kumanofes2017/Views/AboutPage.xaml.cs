
using Kumanofes2017.Models;
using Kumanofes2017.ViewModels;
using Xamarin.Forms;

namespace Kumanofes2017.Views
{
	public partial class AboutPage : ContentPage
	{
        AboutViewModel viewModel;
		public AboutPage()
		{
			InitializeComponent();

            BindingContext = this.viewModel = new AboutViewModel();
		}

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as InfoItem;
            if (item == null)
                return;

            await Navigation.PushAsync(new InfoDetailPage(new InfoDetailViewModel(item)));

            // Manually deselect item
            InfoListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
