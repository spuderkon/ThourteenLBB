using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FourteenLBB.ViewModel
{
    public class CurrentProduct : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void Notify([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public ObservableCollection<Product> Products { get; set; }

        private Product _selectedProduct = new Product();

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                Notify("SelectedProduct");
            }
        }
        public CurrentProduct()
        {
            using (FileStream fs = new FileStream("products.json", FileMode.Open))
            {
                Products = JsonSerializer.Deserialize<ObservableCollection<Product>>(fs);
            }
            Products = new ObservableCollection<Product>
             {
                 new Product { Model="ВАЗ-2105", Category="Car",Price=78000},
                 new Product { Model="Demis Burregovich", Category="Car",Price=2600000},
                 new Product { Model="LG-276", Category="Vacuum cleaner",Price=12999},
                 new Product { Model="Logitech-G316", Category="Computer Mouse",Price=5600},
             };
        }
        public void AddCar()
        {
            Products.Insert(0, _selectedProduct);
        }

        public void DeleteCar()
        {
            if (SelectedProduct != null)
            {
                Products.Remove(SelectedProduct);
                SelectedProduct = new Product();
            }
        }

        public void DiscountForCategory()
        {
            Products.Where(p => p.Category == _selectedProduct.Category).ToList().ForEach(p => p.Discount =_selectedProduct.Discount);
        }

        public void WritingToFile()
        {
            using (FileStream fs = new FileStream("products.json",FileMode.OpenOrCreate))
            {
               JsonSerializer.Serialize<ObservableCollection<Product>>(fs, Products);
            }
        }
    }
}
