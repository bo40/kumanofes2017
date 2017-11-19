using Kumanofes2017.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kumanofes2017.ViewModels
{
    public class InfoDetailViewModel : BaseViewModel
    {
        public InfoItem Item { get; set; }

        public InfoDetailViewModel(InfoItem item = null)
        {
            Title = item.Text;
            Item = item;
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}
