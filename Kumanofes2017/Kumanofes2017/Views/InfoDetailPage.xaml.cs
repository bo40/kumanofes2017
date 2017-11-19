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
	public partial class InfoDetailPage : ContentPage
	{
        InfoDetailViewModel viewModel;

		public InfoDetailPage ()
		{
			InitializeComponent ();
		}

        public InfoDetailPage(InfoDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
	}
}