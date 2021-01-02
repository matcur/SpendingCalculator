using SpendingCalculator.Ui.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpendingCalculator.Ui.UserControls
{
    /// <summary>
    /// Interaction logic for SpendingCategoryList.xaml
    /// </summary>
    public partial class SpendingCategoryList : UserControl
    {
        public static DependencyProperty SpendingCategoriesProperty;

        public static DependencyProperty SelectedSpendingCategoryProperty;

        public ObservableCollection<SpendingCategoryModel> SpendingCategories { get; set; }

        public SpendingCategoryModel SelectedSpendingCategory { get; set; }

        static SpendingCategoryList()
        {
            SpendingCategoriesProperty = DependencyProperty.Register(
                    "SpendingCategories",
                    typeof(SpendingCategoryModel),
                    typeof(SpendingCategoryList)
                );
            SelectedSpendingCategoryProperty = DependencyProperty.Register(
                    "SelectedSpendingCategory",
                    typeof(SpendingCategoryModel),
                    typeof(SpendingCategoryList)
                );
        }

        public SpendingCategoryList()
        {
            InitializeComponent();
        }
    }
}
