using SpendingCalculator.Extensions;
using SpendingCalculator.Ui.Interfaces;
using SpendingCalculator.Ui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace SpendingCalculator.Ui.ViewModels
{
    class HomeViewModel : ViewModel, Calendarable
    {
        public event Action DateTimePicking = delegate { };

        #region Properties

        public List<TimeSpendingModel> TimeSpendings => timeSpendings;

        public TimeSpendingModel SelectedTimeSpending
        {
            get => selectedTimeSpending;
            set
            {
                selectedTimeSpending = value;
                OnPropertyChanged("SelectedTimeSpending");
                OnPropertyChanged("FilteredSpendedSum");
                selectedTimeSpending.OnTimeSpending(this);
            }
        }

        public CalendarMode CalendarMode
        {
            get => calendarMode;
            set
            {
                calendarMode = value;
                OnPropertyChanged("CalendarMode");
            }
        }

        public int FilteredSpendedSum
        {
            get
            {
                var start = SelectedTimeSpending.Start;
                var end = SelectedTimeSpending.End;
                var filtered = spendings.Where(s => s.Time.IsBetween(start, end));

                return filtered.Sum(s => s.Value);
            }
        }

        public bool NeedShowCalendar
        {
            get => needShowCalendar;
            set
            {
                needShowCalendar = value;
                OnPropertyChanged("NeedShowCalendar");
            }
        }

        #endregion

        private TimeSpendingModel selectedTimeSpending;

        private List<TimeSpendingModel> timeSpendings;

        private List<SpendingModel> spendings = new List<SpendingModel>
        {
            new SpendingModel { Value = 20, Time = DateTime.Now },
            new SpendingModel { Value = 30, Time = DateTime.Now.AddDays(-5) },
            new SpendingModel { Value = 120, Time = DateTime.Now.AddMonths(-2) },
            new SpendingModel { Value = 120, Time = DateTime.Now.AddMonths(-2) },
            new SpendingModel { Value = 10, Time = DateTime.Now.AddDays(-28) },
            new SpendingModel { Value = 10, Time = DateTime.Now.AddDays(-28) },
            new SpendingModel { Value = 10, Time = DateTime.Now.AddDays(-28) },
            new SpendingModel { Value = 240, Time = DateTime.Now },
            new SpendingModel { Value = 240, Time = DateTime.Now },
            new SpendingModel { Value = 240, Time = DateTime.Now },
        };

        private CalendarMode calendarMode;

        private bool needShowCalendar = false;

        public HomeViewModel()
        {
            InitializeTimeSpendings();
            SelectedTimeSpending = timeSpendings[3];
        }

        private void InitializeTimeSpendings()
        {
            var now = DateTime.Now;
            timeSpendings = new List<TimeSpendingModel>
            {
                new DaySpendingModel(),
                new MonthSpendingModel(),
                new YearSpendingMode(),
                new TimeSpendingModel { Name = "Сегодня", Start = now.Date, End = now.AddDays(1).Date },
                new TimeSpendingModel { Name = "Этот месяц", Start = now.ToMonth(), End = now.ToNextMonth() },
                new TimeSpendingModel { Name = "Этот год", Start = now.ToYear(), End = now.ToNextYear() },
            };
        }
    }
}
