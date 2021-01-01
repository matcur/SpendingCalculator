using SpendingCalculator.Core.Loaders;
using SpendingCalculator.Core.Savers;
using SpendingCalculator.Ui.ViewModels;
using System;
using System.Collections.Generic;
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

namespace SpendingCalculator.Ui.Pages
{
    /// <summary>
    /// Interaction logic for NewSpendingPage.xaml
    /// </summary>
    public partial class NewSpendingPage : Page
    {
        public NewSpendingPage()
        {
            InitializeComponent();

            DataContext = new NewSpendingViewModel(new XmlLoader(), new XmlSaver());
        }
    }
}
