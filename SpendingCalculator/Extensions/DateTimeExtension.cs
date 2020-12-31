using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SpendingCalculator.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime ToYear(this DateTime time)
        {
            return new DateTime(time.Year, 1, 1);
        }

        public static DateTime ToNextYear(this DateTime time)
        {
            return new DateTime(time.Year + 1, 1, 1);
        }

        public static DateTime ToMonth(this DateTime time)
        {
            return new DateTime(time.Year, time.Month, 1);
        }

        public static DateTime ToNextMonth(this DateTime time)
        {
            var month = time.Month;
            if (month > 11)
                return new DateTime(time.Year + 1, 1, 1);

            return new DateTime(time.Year, month + 1 , 1);
        }

        public static bool IsBetween(this DateTime time, DateTime start, DateTime end)
        {
            return time > start && time < end;
        }
    }
}
