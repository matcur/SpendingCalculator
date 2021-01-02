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
    /// Interaction logic for TimeSpendingsList.xaml
    /// </summary>
    public partial class TimeSpendingList : UserControl
    {
        public static DependencyProperty TimeSpendingsProperty;

        public static DependencyProperty SelectedTimeSpendingProperty;

        public ObservableCollection<TimeSpendingModel> TimeSpendings { get; set; }

        public TimeSpendingModel SelectedTimeSpending { get; set; }

        static TimeSpendingList()
        {
            TimeSpendingsProperty = DependencyProperty.Register(
                    "TimeSpendings",
                    typeof(TimeSpendingModel),
                    typeof(TimeSpendingList)
                );
            SelectedTimeSpendingProperty = DependencyProperty.Register(
                    "SelectedTimeSpending",
                    typeof(TimeSpendingModel),
                    typeof(TimeSpendingList)
                );
        }

        public TimeSpendingList()
        {
            InitializeComponent();
        }
    }
}
