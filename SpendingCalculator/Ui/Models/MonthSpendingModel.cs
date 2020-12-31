using SpendingCalculator.Ui.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace SpendingCalculator.Ui.Models
{
    class MonthSpendingModel : TimeSpendingModel
    {
        public MonthSpendingModel()
        {
            Name = "Месяц";
        }

        public override void OnTimeSpending(Calendarable calendarable)
        {
            calendarable.NeedShowCalendar = true;
            calendarable.CalendarMode = CalendarMode.Year;
        }
    }
}
