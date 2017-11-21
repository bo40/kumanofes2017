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

            pushButton.Clicked += (sender, e) =>
            {
                MessagingCenter.Send(this, "NOTIFY");
            };
        }

        public ItemDetailPage(ItemDetailViewModel viewModel)
		{
			InitializeComponent();

            pushButton.Clicked += (sender, e) =>
            {
                MessagingCenter.Send(this, "NOTIFY");
            };
            pushItem = JsonConvert.SerializeObject(viewModel.Item);
            pushTitle = viewModel.Item.Text;
            pushMessage = "企画があと" + "で始まります";
            BindingContext = this.viewModel = viewModel;
		}
	}
}
