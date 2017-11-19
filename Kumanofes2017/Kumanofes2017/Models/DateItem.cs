using System;
using System.Collections.Generic;
using System.Text;

namespace Kumanofes2017.Models
{
    public class DateItem : BaseDataObject
    {
        string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }
    }
}
