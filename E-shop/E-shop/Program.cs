using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
namespace E_shop
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Product> products = new List<Product>()
            {
                new Product("Milk", 50, 100, 1),
                new Product("Water", 20, 50, 2),
                new Product("Milka Chocolate", 50, 90, 3),
                new Product("Coca Cola", 50, 200, 4),
                new Product("Gazoza", 40, 200, 5),
                new Product("Chocolate Milk", 50, 50, 6),
                new Product("Soya sauce", 70, 20, 7),
                new Product("Tomato sauce", 60, 20, 8),
                new Product("Pork meat", 150, 100, 9),
                new Product("Chicken meat", 120, 100, 10),
                new Product("Bread", 30, 20, 11),
                new Product("Cigarettes", 80, 100, 12)
            };



            while (true)
            {

                #region User
                Console.WriteLine("Please enter your name:");
                string User = Console.ReadLine();
                List<Product> UserCart = new List<Product>();

                #endregion

                while (true)
                {
                    Console.WriteLine("1.Get the whole list of products | 2.Search product | 3.Remove order | 4.Finish the shopping ");

                    #region Get the whole list
                    string UserInput = Console.ReadLine();
                    if (UserInput == "1")
                    {
                        while (true)
                        {
                            foreach (var product in products)
                            {
                                product.PrintInfo();
                            }

                            Console.WriteLine("1.Order product | 2.Get the state of shoping cart | 3.Back to menu");
                            if (Console.ReadLine() == "1")
                            {
                                Console.Clear();
                                while (true)
                                {
                                    foreach (var product in products)
                                    {
                                        product.PrintInfo();
                                    }
                                    Console.WriteLine("Enter the order number of product that you want to order!");
                                    Console.Write("New order: ");
                                    int order = int.Parse(Console.ReadLine());
                                    var choosedProductExist = UserCart.Any(x => x.Id == order);

                                    if (choosedProductExist)
                                    {
                                        Product choosedProduct = products.FirstOrDefault(x => x.Id == order);
                                        choosedProduct.PrintInfo();
                                        var choosedProductTrue = UserCart.FirstOrDefault(x => x.Id == order);
                                        Console.Write("Quantity: ");
                                        int productQuantity = int.Parse(Console.ReadLine());
                                        if (productQuantity <= choosedProductTrue.Quantity)
                                        {
                                            choosedProductTrue.Quantity +=  productQuantity;
                                        }
                                        else Console.WriteLine("We dont have that much.");
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"You ordered {choosedProductTrue.Name}!!");
                                        Console.ResetColor();

                                        //Apdejtiranje na listata so produkti
                                        RemoveProduct(products, choosedProduct);
                                        Product p = choosedProduct - productQuantity;
                                        if (p.Quantity != 0)
                                        {
                                            products.Add(p);
                                        }
                                    }
                                    else if (choosedProductExist == false)
                                    {
                                        Product choosedProduct = products.FirstOrDefault(x => x.Id == order);
                                        if (choosedProduct != null)
                                        {
                                            choosedProduct.PrintInfo();

                                            Console.Write("Quantity: ");
                                            int productQuantity = int.Parse(Console.ReadLine());
                                            if (productQuantity <= choosedProduct.Quantity)
                                            {
                                                UserCart.Add(NewOrder(choosedProduct, productQuantity));
                                            }
                                            else Console.WriteLine("We dont have that much.");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine($"You ordered {choosedProduct.Name}!!");
                                            Console.ResetColor();
                                           

                                            //Apdejtiranje na listata so produkti
                                            RemoveProduct(products, choosedProduct);
                                            Product p = choosedProduct - productQuantity;
                                            if (p.Quantity != 0)
                                            {
                                                products.Add(p);
                                            }
                                        }
                                        else Console.WriteLine("Cant find that product");

                                    }
                                    else Console.WriteLine("Cant find that product");
                                    Console.WriteLine("1.To continue ordering | 2.To finish ordering");
                                    if (Console.ReadLine() == "1") continue;
                                    else if (Console.ReadLine() == "2") break;
                                    else break;
                                }
                            }
                            else if(Console.ReadLine() == "2")
                            {
                               
                                Console.WriteLine("You had ordered:");
                                foreach (var product in UserCart)
                                {
                                    product.PrintInfo();
                                }
                                Console.WriteLine($"Total price: {TotalPrice(UserCart)}");
                                
                            }


                            Console.WriteLine("1.Back | 2.Exit");
                            if (Console.ReadLine() == "1") continue;
                            else break;
                        }
                    }



                    #endregion

                    #region Search product
                    else if (UserInput == "2")
                    {
                        while (true)
                        {
                            Console.Write("Search:  ");
                            string UserSearch = Console.ReadLine();
                            List<Product> SearchedProducts = products.Where(x => x.Name.Contains(UserSearch)).ToList();
                            if (SearchedProducts != null && UserSearch is string)
                            {
                                foreach (var product in SearchedProducts)
                                {
                                    product.PrintInfo();
                                }
                            }
                            else  Console.WriteLine("Cant find that product!"); 
                            Console.WriteLine("1.Order that product | 2.Search again | 3.Get the state of shoping cart | 4.Menu");
                                if (Console.ReadLine() == "1")
                                {
                                    Console.WriteLine("Enter the order number of product that you want to order!");
                                    Console.Write("New order: ");
                                    int order = int.Parse(Console.ReadLine());
                                    var choosedProductExist = UserCart.Any(x => x.Id == order);


                                    if (choosedProductExist)
                                    {
                                        Product choosedProduct = products.FirstOrDefault(x => x.Id == order);
                                        choosedProduct.PrintInfo();
                                        var choosedProductTrue = UserCart.FirstOrDefault(x => x.Id == order);
                                        Console.Write("Quantity: ");
                                        int productQuantity = int.Parse(Console.ReadLine());
                                        if (productQuantity <= choosedProductTrue.Quantity)
                                        {
                                            choosedProductTrue.Quantity += productQuantity;
                                        }
                                        else Console.WriteLine("We dont have that much.");
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"You ordered {choosedProductTrue.Name}!!");
                                        Console.ResetColor();

                                        //Apdejtiranje na listata so produkti
                                        RemoveProduct(products, choosedProduct);
                                        Product p = choosedProduct - productQuantity;
                                        if (p.Quantity != 0)
                                        {
                                            products.Add(p);
                                        }
                                    }
                                    else if (choosedProductExist == false)
                                    {
                                        Product choosedProduct = products.FirstOrDefault(x => x.Id == order);
                                        if (choosedProduct != null)
                                        {
                                            choosedProduct.PrintInfo();

                                            Console.Write("Quantity: ");
                                            int productQuantity = int.Parse(Console.ReadLine());
                                            if (productQuantity <= choosedProduct.Quantity)
                                            {
                                                UserCart.Add(NewOrder(choosedProduct, productQuantity));
                                            }
                                            else Console.WriteLine("We dont have that much.");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine($"You ordered {choosedProduct.Name}!!");
                                            Console.ResetColor();


                                            //Apdejtiranje na listata so produkti
                                            RemoveProduct(products, choosedProduct);
                                            Product p = choosedProduct - productQuantity;
                                            if (p.Quantity != 0)
                                            {
                                                products.Add(p);
                                            }
                                        }
                                        else Console.WriteLine("Cant find that product");

                                    }

                                }
                                else if (Console.ReadLine() == "2") continue;
                                else if (Console.ReadLine() == "3")
                                {
                                    Console.WriteLine("You had ordered:");
                                    foreach (var product in UserCart)
                                    {
                                        product.PrintInfo();
                                    }
                                    Console.WriteLine($"Total price: {TotalPrice(UserCart)}");
                                    break;
                                }
                                else break;
                        }
                    }
                    #endregion

                    #region Remove order
                    else if (UserInput == "3")
                    {
                        Console.WriteLine("Enter the order number of the product that you want to remove:");
                        foreach (var product in UserCart)
                        {
                            product.PrintInfo();
                        }
                        int productId = int.Parse( Console.ReadLine());
                        Product productToRemove = products.Find(x => x.Id == productId);
                        if(productToRemove != null)
                        {
                             RemoveProduct(UserCart, productToRemove);
                        }
                        Console.WriteLine("Orders left:");
                        foreach (var product in UserCart)
                        {
                            product.PrintInfo();
                        }

                    }
                    #endregion

                    #region Finish
                    else if (UserInput == "4")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Shopping finished!");
                        Console.WriteLine(User);
                        foreach (var product in UserCart)
                        {
                            product.PrintInfo();
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Total price: {TotalPrice(UserCart)}");
                        Console.ResetColor();
                    }
                    #endregion

                    Console.WriteLine("1.Back to menu 2.Exit");
                    if (Console.ReadLine() == "1") continue;
                    else if (Console.ReadLine() == "2") break;
                    else break;
                }
            }



            
        }



        public static Product NewOrder(Product p, int input)
        {
            Product a = new Product
            {
                Name = p.Name,
                Price = p.Price,
                Quantity = input,
                Id = p.Id

            };
            return a;
        }

        public static int TotalPrice(List<Product> p)
        {
            int totalPrice = 0;
            foreach (var item in p)
            {
                totalPrice += (item.Price * item.Quantity);
            }
            return totalPrice;
        }

        public static List<Product> RemoveProduct(List<Product> l, Product p)
        {
            Product remove = l.Single(x => x.Id == p.Id);
            l.Remove(remove);
            return l;
           
        }

    }
}
