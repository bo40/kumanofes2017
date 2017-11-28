using System;
using System.Collections.Generic;
using System.Text;

namespace Kumanofes2017.Models
{
    public class Notification
    {
        public Notification()
        {
        }

        public Notification(string Id)
        {
            this.Id = Id;
        }
        
        public Notification(string Id, int min, long time_millis)
        {
            this.Id = Id;
            ThirtyMinPush = 0;
            AnHourPush = 0;
            TwoHoursPush = 0;
            ThreeHoursPush = 0;
            ADayPush = 0;
            switch(min)
            {
                case 30:
                    ThirtyMinPush = time_millis;
                    break;
                case 60:
                    AnHourPush = time_millis;
                    break;
                case 120:
                    TwoHoursPush = time_millis;
                    break;
                case 180:
                    ThreeHoursPush = time_millis;
                    break;
                case 1440:
                    ADayPush = time_millis;
                    break;
                default:
                    break;
            }
        }

        public string Id { get; set; }
        public long ThirtyMinPush { get; set; }
        public long AnHourPush { get; set; }
        public long TwoHoursPush { get; set; }
        public long ThreeHoursPush { get; set; }
        public long ADayPush { get; set; }

        public string jsonItem { get; set; }
        public string title { get; set; }
        public string message { get; set; }

        public long GetPushTime(int min)
        {
            switch(min)
            {
                case 30:
                    return ThirtyMinPush;
                case 60:
                    return AnHourPush;
                case 120:
                    return TwoHoursPush;
                case 180:
                    return ThreeHoursPush;
                case 1440:
                    return ADayPush;
                default:
                    return 0;
            }
        }

        public void SetPushTime(int min, long time_millis)
        {
            switch (min)
            {
                case 30:
                    ThirtyMinPush = time_millis;
                    break;
                case 60:
                    AnHourPush = time_millis;
                    break;
                case 120:
                    TwoHoursPush = time_millis;
                    break;
                case 180:
                    ThreeHoursPush = time_millis;
                    break;
                case 1440:
                    ADayPush = time_millis;
                    break;
                default:
                    break;
            }
        }
    }
}
