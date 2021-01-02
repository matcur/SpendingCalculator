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
    /// Interaction logic for SpendingsList.xaml
    /// </summary>
    public partial class SpendingList : UserControl
    {
        public static DependencyProperty SpendingsProperty;

        public ObservableCollection<SpendingModel> Spendings { get; set; }

        static SpendingList()
        {
            SpendingsProperty = DependencyProperty.Register(
                    "Spendings",
                    typeof(SpendingModel),
                    typeof(SpendingList)
                );
        }

        public SpendingList()
        {
            InitializeComponent();
        }
    }
}
