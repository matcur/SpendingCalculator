using SpendingCalculator.Core.Interfaces;
using SpendingCalculator.Extensions;
using SpendingCalculator.Ui.Commands;
using SpendingCalculator.Ui.Interfaces;
using SpendingCalculator.Ui.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace SpendingCalculator.Ui.ViewModels
{
    class HomeViewModel : ViewModel, Calendarable
    {
        #region Properties

        public List<TimeSpendingModel> TimeSpendings => timeSpendings;

        public ObservableCollection<SpendingCategoryModel> SpendingCategories => spendingCategories;

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

        public SpendingCategoryModel SelectedSpendingCategory 
        { 
            get => selectedSpendingCategory;
            set
            {
                selectedSpendingCategory = value;
                OnPropertyChanged("SelectedSpendingCategory");
                OnPropertyChanged("FilteredSpendedSum");
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
                var filtered = spendings.Where(s => IsFilteredSpending(s));

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

        private List<TimeSpendingModel> timeSpendings;

        private ObservableCollection<SpendingModel> spendings;

        private ObservableCollection<SpendingCategoryModel> spendingCategories;

        private TimeSpendingModel selectedTimeSpending;

        private SpendingCategoryModel selectedSpendingCategory;

        private readonly ILoader loader;

        private readonly string spendingsFilePath = ConfigurationManager.AppSettings.Get("SpendingsFilePath");
        
        private readonly string spendingCategoriesFilePath = ConfigurationManager.AppSettings.Get("SpendingCategoriesFilePath");

        private CalendarMode calendarMode;

        private bool needShowCalendar = false;

        public HomeViewModel(ILoader loader)
        {
            this.loader = loader;
            InitializeSpendingCategories();
            InitializeTimeSpendings();
            InitializeSpendings();

            SelectedTimeSpending = timeSpendings[3];
        }

        private void InitializeSpendings()
        {
            spendings = loader.Load<ObservableCollection<SpendingModel>>(spendingsFilePath);
        }

        private void InitializeSpendingCategories()
        {
            spendingCategories = loader.Load<ObservableCollection<SpendingCategoryModel>>(spendingCategoriesFilePath);
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

        private bool IsFilteredSpending(SpendingModel spending)
        {
            if (SelectedSpendingCategory == null)
                return true;

            var start = SelectedTimeSpending.Start;
            var end = SelectedTimeSpending.End;

            return spending.CreatedAt.IsBetween(start, end) &&
                   spending.CategoryId == SelectedSpendingCategory.Id;
        }
    }
}
