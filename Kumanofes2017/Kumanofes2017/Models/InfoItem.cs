using System;
using System.Collections.Generic;
using System.Text;

namespace Kumanofes2017.Models
{
    public class InfoItem : BaseDataObject
    {
        string text = string.Empty;
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        string time = string.Empty;
        public string Time
        {
            get { return time; }
            set { SetProperty(ref time, value); }
        }

        string detail = string.Empty;
        public string Detail
        {
            get { return detail; }
            set { SetProperty(ref detail, value); }
        }
    }
}
