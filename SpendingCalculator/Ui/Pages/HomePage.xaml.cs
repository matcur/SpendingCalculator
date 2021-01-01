using SpendingCalculator.Core.Loaders;
using SpendingCalculator.Core.Savers;
using SpendingCalculator.Ui.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Policy;
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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();

            DataContext = new HomeViewModel(new XmlLoader());
        }

        private void NavigateToNewSpendingPage(object sender, RoutedEventArgs e)
        {
            NavigateToPage(new NewSpendingPage());
        }

        private void NavigateToPage(Page page)
        {
            NavigationService.Navigate(page);
        }
    }
}
