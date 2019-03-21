using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfEvil
{
    struct OpeningTimeRange
    {
        public OpeningTimeRange(TimeSpan OpenAt,TimeSpan ClosedAt) : this()
        {
            this.OpenAt = OpenAt;
            this.ClosedAt = ClosedAt;
        }
        public TimeSpan OpenAt { get; set; }
        public TimeSpan ClosedAt { get; set; }
    }

    public class OpeningHours
    {
        public OpeningHours()
        {
            openTime = new Dictionary<DayOfWeek, OpeningTimeRange>
            {
                {DayOfWeek.Monday,new OpeningTimeRange(new TimeSpan(10,30,00),new TimeSpan(19,00,00)) },
                {DayOfWeek.Tuesday,new OpeningTimeRange(new TimeSpan(10,30,00),new TimeSpan(19,00,00)) },
                {DayOfWeek.Wednesday,new OpeningTimeRange(new TimeSpan(10,30,00),new TimeSpan(19,00,00)) },
                {DayOfWeek.Thursday,new OpeningTimeRange(new TimeSpan(10,30,00),new TimeSpan(19,00,00)) },
                {DayOfWeek.Friday,new OpeningTimeRange(new TimeSpan(10,30,00),new TimeSpan(19,00,00)) },
                {DayOfWeek.Saturday,new OpeningTimeRange(new TimeSpan(10,30,00),new TimeSpan(14,00,00)) },
            };
        }
        private Dictionary<DayOfWeek, OpeningTimeRange> openTime;

        public bool IsOpen(DateTime dateTime)
        {
            return openTime.ContainsKey(dateTime.DayOfWeek) &&
                   openTime[dateTime.DayOfWeek].OpenAt <= dateTime.TimeOfDay &&
                   openTime[dateTime.DayOfWeek].ClosedAt > dateTime.TimeOfDay;
        }

        public bool IsNowOpen()
        {
            return IsOpen(DateTime.Now); // UnitTest funzt am Freitag aber am Sonntag nicht !!!
        }
            
    }
}
