using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreLibrary
{
    [DataContract]
    public class Product : IComparable<Product>
    {
        [DataMember]
        public double price;
        [DataMember]
        public string title;
        public double Price
        {
            get => price;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Значение price меньше нуля");
                price = value;
            }
        }

        public string Title
        {
            get => title;
            set
            {
                if (value == "" || value == null)
                    throw new ArgumentException("Пустая строка");
                title = value;
            }
        }

        public static explicit operator double(Product product)
        {
            return product.Price;
        }

        public int CompareTo(Product product)
        {
            return Price > product.Price ? 1 : (Price == product.Price ? 0 : -1);
        }

        public override string ToString()
        {
            return $"Price = ${Price:F2}";
        }
    }
}
