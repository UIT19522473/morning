using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListNote
{
    public class Job
    {
        protected string timeReminder;
        protected string dateTimeEnd;
        protected string dTPK;
        protected string eventName;
        protected string locations;
        protected string dateTimeStart;
        protected string eventDescription;
        protected string timeInDayStart;
        protected string timeInDayEnd;
        protected bool ckbAllDay;

        public string DTPK { get => dTPK; set => dTPK = value; }
        public string EventName { get => eventName; set => eventName = value; }
        public string TimeReminder { get => timeReminder; set => timeReminder = value; }
        public string Locations { get => locations; set => locations = value; }
        public string DateTimeStart { get => dateTimeStart; set => dateTimeStart = value; }
        public string DateTimeEnd { get => dateTimeEnd; set => dateTimeEnd = value; }
        public string TimeInDayStart { get => timeInDayStart; set => timeInDayStart = value; }
        public string TimeInDayEnd { get => timeInDayEnd; set => timeInDayEnd = value; }
        public bool CkbAllDay { get => ckbAllDay; set => ckbAllDay = value; }
        public string EventDescription { get => eventDescription; set => eventDescription = value; }

        public Job()
        {
            timeReminder = "";
            dateTimeEnd = "";
            dTPK = "";
            eventName = "";
            locations = "";
            dateTimeStart = "";
            ckbAllDay = false;
            timeInDayStart = "";
            timeInDayEnd = "";
            eventDescription = "";

        }
        public Job(string a,string b,string c, string d, string e,string f,string j,string h,string i,bool k,string l)
        {
            this.dTPK = a;this.timeReminder = c;this.eventName = d;this.locations = e;this.dateTimeStart = f;this.dateTimeEnd = j;
            this.timeInDayStart = h;this.timeInDayEnd = i;this.ckbAllDay = k;this.eventDescription = l;
        }

    }
}
