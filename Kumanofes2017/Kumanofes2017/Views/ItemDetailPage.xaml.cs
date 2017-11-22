using System.Reflection;
using Kumanofes2017.ViewModels;

using Xamarin.Forms;
using Newtonsoft.Json;

namespace Kumanofes2017.Views
{
	public partial class ItemDetailPage : ContentPage
	{
		ItemDetailViewModel viewModel;
        public string pushItem { get; }
        public string pushTitle { get; }
        public string pushMessage { get; }

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent();
        }

        public ItemDetailPage(ItemDetailViewModel viewModel)
		{
			InitializeComponent();

            pushButton.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new AlarmSetPage(viewModel.Item));
            };
            BindingContext = this.viewModel = viewModel;
		}
	}
}
