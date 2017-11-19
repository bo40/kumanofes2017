namespace Kumanofes2017.Models
{
    public class Item : BaseDataObject
    {
        string type = string.Empty;
        public string Type
        {
            get { return type; }
            set { SetProperty(ref type, value); }
        }

		string text = string.Empty;
		public string Text
		{
			get { return text; }
			set { SetProperty(ref text, value); }
		}

		string description = string.Empty;
		public string Description
		{
			get { return description; }
			set { SetProperty(ref description, value); }
		}

        string date_id = string.Empty;
        public string DateId
        {
            get { return date_id; }
            set { SetProperty(ref date_id, value); }
        }

        string start = string.Empty;
        public string Start
        {
            get { return start; }
            set { SetProperty(ref start, value); }
        }

        public string StartWithCaption
        {
            get { return "開始時間 : " + start; }
        }

        string end = string.Empty;
        public string End
        {
            get { return end; }
            set { SetProperty(ref end, value); }
        }

        public string EndWithCaption
        {
            get { return "終了時間 : " + end; }
        }

        public string Time
        {
            get
            {
                if (type == "guerrilla")
                {
                    return "ゲリラ企画";
                }
                else if (type == "permanent")
                {
                    return "常設企画";
                }
                return start + " ~ " + end;
            }
        }

        string place = string.Empty;
        public string Place
        {
            get { return place; }
            set { SetProperty(ref place, value); }
        }

        public string PlaceWithCaption
        {
            get { return "場所 : " + place;
            }
        }

        string image_path = string.Empty;
        public string ImagePath
        {
            get { return image_path; }
            set { SetProperty(ref image_path, value); }
        }
	}
}
