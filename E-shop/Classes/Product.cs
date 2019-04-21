using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Id { get; set; }

        public Product(string name, int price, int quantity, int id)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
            this.Id = id;
        }

        public Product() { }

        public void PrintInfo()
        {
            Console.WriteLine($"Name:{Name}, Price:{Price}, Quantity:{Quantity}, Order Number:{Id}");
        }

        public static Product operator -(Product p, int input)
        {
            Product a = new Product
            {
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity - input,
                Id = p.Id

            };
            return a;
        }

        
    }
}
