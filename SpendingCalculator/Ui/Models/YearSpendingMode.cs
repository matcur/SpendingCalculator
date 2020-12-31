using SpendingCalculator.Ui.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace SpendingCalculator.Ui.Models
{
    class YearSpendingMode : TimeSpendingModel
    {
        public override DateTime End 
        { 
            get => Start.AddYears(1);
            set => base.End = value;
        }

        public YearSpendingMode()
        {
            Name = "Год";
        }

        public override void OnTimeSpending(Calendarable calendarable)
        {
            calendarable.NeedShowCalendar = true;
            calendarable.CalendarMode = CalendarMode.Decade;
        }
    }
}
