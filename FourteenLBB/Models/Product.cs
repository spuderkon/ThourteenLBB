using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FourteenLBB
{
    public class Product : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private string _model;

        private decimal _price;

        public static string[] _categories { get; } = new string[] {"Car", "Vacuum cleaner", "Computer mouse" };

        private double _discount;

        private string _category;
        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
                Notify("Category");
            }
        }

        public string Model
        {
            get { return _model; }
            set
            {
                _model = value;
                Notify("Model");
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                Notify("Price");
                Notify("DiscountPrice");
            }
        }

        public double Discount
        {
            get
            { return _discount; }
            set
            {
                _discount = value;
                Notify("Discount");
                Notify("DiscountPrice");
            }
        }

       public decimal DiscountPrice
        {
            get
            {
                return Price * (decimal)(1 - Discount);
            }
        }
    }
}
