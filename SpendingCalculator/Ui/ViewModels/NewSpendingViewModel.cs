using SpendingCalculator.Core.Interfaces;
using SpendingCalculator.Ui.Commands;
using SpendingCalculator.Ui.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Text;

namespace SpendingCalculator.Ui.ViewModels
{
    class NewSpendingViewModel : ViewModel
    {
        public ObservableCollection<SpendingCategoryModel> SpendingCategories => spendingCategories;

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

        private ObservableCollection<SpendingCategoryModel> spendingCategories;

        private SpendingCategoryModel selectedSpendingCategory;

        private SpendingModel newSpending = new SpendingModel();
        
        private readonly ILoader loader;

        private readonly ISaver saver;

        private readonly string spendingsFilePath = ConfigurationManager.AppSettings.Get("SpendingsFilePath");

        private readonly string spendingCategoriesFilePath = ConfigurationManager.AppSettings.Get("SpendingCategoriesFilePath");

        public NewSpendingViewModel(ILoader loader, ISaver saver)
        {
            this.loader = loader;
            this.saver = saver;
            InitializeSpendings();
            InitializeSpendingCategories();
            InitializeCommands();
            SelectedSpendingCategory = SpendingCategories[0];
        }

        private void InitializeSpendings()
        {
            spendings = loader.Load<ObservableCollection<SpendingModel>>(spendingsFilePath);
        }

        private void InitializeSpendingCategories()
        {
            spendingCategories = loader.Load<ObservableCollection<SpendingCategoryModel>>(spendingCategoriesFilePath);
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
                CreatedAt = DateTime.Now,
            });

            newSpending.Value = 0;
            SaveSpendings();
        }

        private void SaveSpendings()
        {
            saver.Save(spendings, spendingsFilePath);
        }
    }
}
