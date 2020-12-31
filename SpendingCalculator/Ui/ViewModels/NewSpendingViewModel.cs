using SpendingCalculator.Ui.Commands;
using SpendingCalculator.Ui.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SpendingCalculator.Ui.ViewModels
{
    class NewSpendingViewModel : ViewModel
    {
        public ObservableCollection<SpendingCategoryModel> SpendingCategories { get; } = new ObservableCollection<SpendingCategoryModel>
        {
            new SpendingCategoryModel{ Name = "Транспорт", Id = 1 },
            new SpendingCategoryModel{ Name = "Еда", Id = 2 },
            new SpendingCategoryModel{ Name = "Досуг", Id = 3 },
            new SpendingCategoryModel{ Name = "Кафе", Id = 4 },
            new SpendingCategoryModel{ Name = "Прочее", Id = 5 },
        };

        public ObservableCollection<SpendingModel> Spendings => spendings;

        public SpendingCategoryModel SelectedSpendingCategory
        {
            get => selectedSpendingCategory;
            set
            {
                selectedSpendingCategory = value;
                OnPropertyChanged("SelectedSpendingCategory");
            }
        }

        public SpendingModel NewSpending
        {
            get => newSpending;
            set
            {
                newSpending = value;
                OnPropertyChanged("NewSpending");
            }
        }

        public ReplyCommand AddNewSpendingCommand { get; set; }

        private ObservableCollection<SpendingModel> spendings;
        
        private SpendingCategoryModel selectedSpendingCategory;

        private SpendingModel newSpending = new SpendingModel();

        public NewSpendingViewModel()
        {
            InitializeSpendings();
            InitializeCommands();
            SelectedSpendingCategory = SpendingCategories[0];
        }

        private void InitializeSpendings()
        {
            spendings = new ObservableCollection<SpendingModel>
            {
                new SpendingModel{ Value = 1234 },
                new SpendingModel{ Value = 134 },
                new SpendingModel{ Value = 124 },
                new SpendingModel{ Value = 12354 },
            };
        }

        private void InitializeCommands()
        {
            AddNewSpendingCommand = new ReplyCommand(AddNewSending);
        }

        private void AddNewSending(object o)
        {
            spendings.Add(new SpendingModel 
            { 
                Value = newSpending.Value,
                CategoryId = SelectedSpendingCategory.Id,
            });

            newSpending.Value = 0;
        }
    }
}
