using SpendingCalculator.Extensions;
using SpendingCalculator.Ui.Commands;
using SpendingCalculator.Ui.Interfaces;
using SpendingCalculator.Ui.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private List<SpendingModel> spendings;

        private ObservableCollection<SpendingCategoryModel> spendingCategories;

        private TimeSpendingModel selectedTimeSpending;

        private SpendingCategoryModel selectedSpendingCategory;

        private CalendarMode calendarMode;

        private bool needShowCalendar = false;

        public HomeViewModel()
        {
            InitializeSpendings();
            InitializeTimeSpendings();
            InitializeSpendingCategories();
            SelectedTimeSpending = timeSpendings[3];
        }

        private void InitializeSpendings()
        {
            var now = DateTime.Now;
            spendings = new List<SpendingModel>
            {
                new SpendingModel { Value = 20, CreatedAt = now, CategoryId = 1 },
                new SpendingModel { Value = 30, CreatedAt = now.AddDays(-5), CategoryId = 1 },
                new SpendingModel { Value = 120, CreatedAt = now.AddMonths(-2), CategoryId = 1 },
                new SpendingModel { Value = 120, CreatedAt = now.AddMonths(-2), CategoryId = 2 },
                new SpendingModel { Value = 10, CreatedAt = now.AddDays(-28), CategoryId = 1 },
                new SpendingModel { Value = 10, CreatedAt = now.AddDays(-28), CategoryId = 4 },
                new SpendingModel { Value = 10, CreatedAt = now.AddDays(-28), CategoryId = 3 },
                new SpendingModel { Value = 240, CreatedAt = now, CategoryId = 4 },
                new SpendingModel { Value = 240, CreatedAt = now, CategoryId = 2 },
                new SpendingModel { Value = 240, CreatedAt = now, CategoryId = 2 },
            };
        }

        private void InitializeSpendingCategories()
        { 
            spendingCategories = new ObservableCollection<SpendingCategoryModel>
            {
                new SpendingCategoryModel{ Name = "Транспорт", Id = 1 },
                new SpendingCategoryModel{ Name = "Еда", Id = 2 },
                new SpendingCategoryModel{ Name = "Досуг", Id = 3 },
                new SpendingCategoryModel{ Name = "Кафе", Id = 4 },
                new SpendingCategoryModel{ Name = "Прочее", Id = 5 },
            };
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
            var start = SelectedTimeSpending.Start;
            var end = SelectedTimeSpending.End;

            return spending.CreatedAt.IsBetween(start, end) &&
                   DoCategoryMatch(spending);
        }

        private bool DoCategoryMatch(SpendingModel spending)
        {
            return SelectedSpendingCategory == null ||
                   spending.CategoryId == SelectedSpendingCategory.Id;
        }
    }
}
