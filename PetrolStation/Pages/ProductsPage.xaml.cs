using PetrolStation.Core;
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

namespace PetrolStation
{
    /// <summary>
    /// Logika interakcji dla klasy ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public ProductsPage()
        {
           InitializeComponent();
          //  DataContext = new ProductsPageViewModel();
        }

        private void FuelLIstView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
