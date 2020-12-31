using SpendingCalculator.Ui.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls.Primitives;

namespace SpendingCalculator.Ui.Models
{
    class TimeSpendingModel : Model
    {
        public string Name { get; set; }

        public DateTime Start
        {
            get => start;
            set
            {
                start = value;
                OnPropertyChanged("Start");
            }
        }

        public virtual DateTime End
        {
            get => end;
            set
            {
                end = value;
                OnPropertyChanged("End");
            }
        }

        public virtual void OnTimeSpending(Calendarable calendarable)
        {
            calendarable.NeedShowCalendar = false;
        }

        protected DateTime start;

        protected DateTime end;
    }
}
