using SpendingCalculator.Ui.Interfaces;
using System.Windows.Controls;

namespace SpendingCalculator.Ui.Models
{
    class DaySpendingModel : TimeSpendingModel
    {
        public DaySpendingModel()
        {
            Name = "День";
        }

        public override void OnTimeSpending(Calendarable calendarable)
        {
            calendarable.NeedShowCalendar = true;
            calendarable.CalendarMode = CalendarMode.Month;
        }
    }
}
