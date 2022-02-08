using FourteenLBB.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FourteenLBB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new CurrentProduct();
            ComBoxCateg.ItemsSource = Product._categories;
            DiscountField.Text = DisountSlider.Value.ToString();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ((CurrentProduct)DataContext).AddCar();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ((CurrentProduct)DataContext).DeleteCar();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((CurrentProduct)DataContext).DiscountForCategory();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ((CurrentProduct)DataContext).WritingToFile();
        }
    }
}
