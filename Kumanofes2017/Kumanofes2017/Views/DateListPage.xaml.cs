using Kumanofes2017.ViewModels;
using Kumanofes2017.Models;
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
	public partial class DateListPage : ContentPage
	{
        DateListViewModel viewModel;

        public DateListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new DateListViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = (DateItem)args.SelectedItem;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemsPage(new ItemsViewModel(item)));

            // Manually deselect item
            DateListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.DateList.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}