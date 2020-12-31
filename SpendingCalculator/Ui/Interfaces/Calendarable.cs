using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace SpendingCalculator.Ui.Interfaces
{
    interface Calendarable
    {
        CalendarMode CalendarMode { get; set; }

        bool NeedShowCalendar { get; set; }
    }
}
