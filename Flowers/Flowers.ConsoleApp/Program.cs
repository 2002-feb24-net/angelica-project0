using System;
using Microsoft.EntityFrameworkCore;
using Flowers.Data;
using Flowers.ConsoleApp.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;



namespace Flowers.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int userOption = Menu();
            if(userOption == 1)
            {
                // creates a new customer in the db
                AddCustomer();
            }
            else if (userOption == 2)
            {
                // reads an existing customer in the db
                ReadCustomer();
            }
            else if (userOption == 3)
            {
                // creates a new order for a product
                AddOrder();
            }
            else if (userOption == 4)
            {
                // tells store locations
                ReadStore();
            }
            else if (userOption == 5)
            {
                // tells inventory based on store location
                ReadInventory();
            }
            else 
            {
                // exits 
                Quit();
            }
                


        }
// this is a menu that prompts a user to enter in a number. depending on the number they choose will
// dictate what method is called. 
        public static int Menu()
        {
            int [] UserOptions = {1, 2, 3, 4, 5, 6};
            bool choice = true;
            int UserChoice = 0;
            do{
                Console.WriteLine("Welcome to the flower shop!");
                Console.WriteLine("Please select an option from the options menu: ");
                Console.WriteLine("i.e to log in as a new customer, type in 1");
                Console.WriteLine("1. Log in as a new customer");
                Console.WriteLine("2. Log in as an existing customer");
                Console.WriteLine("3. Place an order");
                Console.WriteLine("4. View store locations");
                Console.WriteLine("5. View store inventory");
                Console.WriteLine("6. Exit"); 

                UserChoice = int.Parse(Console.ReadLine());
                for(int i=0; i < UserOptions.Length; i++)
                {
                    if(UserOptions[i] == UserChoice)
                    {
                        choice = false;
                    }
                }
                
            } while(choice);
            return UserChoice;
        }

        public static void Quit()
        {
            Console.WriteLine("Goodbye! Come back soon.");
        }

        public static void AddCustomer()
        {
            System.Console.WriteLine("Please enter your first name: ");
            string firstName = Console.ReadLine();

            System.Console.WriteLine("Please enter your last name: ");
            string lastName = Console.ReadLine();

            System.Console.WriteLine("Please enter a username: ");
            string userName = Console.ReadLine();

            using (var context = new Flowers.ConsoleApp.Entities.FlowersContext())
            {
                var newCustomer = new Flowers.ConsoleApp.Entities.Customer{
                    FirstName = firstName,
                    LastName = lastName,
                    Username =userName
                };

                context.Customer.Add(newCustomer);
                context.SaveChanges();
            }

            Menu(); // here the method will call the menu to give the user the options to keep going

        }

        public static void ReadCustomer()
        {
            System.Console.WriteLine("Log in as an existing customer");
            System.Console.WriteLine("Please enter your username: ");
            string userName = Console.ReadLine();

            // using (var context = new Flowers.ConsoleApp.Entities.FlowersContext())
            //     {
            //     var row = context.Customer.Find();
            //         Console.WriteLine(row.UserName);
            //     }

                // log in as an existing customer by using username. if user input == value in table, then logged in. 
                // create another menu that doesnt include the part where it says log in (1 and 2 on original menu)
                // run code based on choice from new menu. 

        }

        public static void AddOrder()
        {
            Console.WriteLine("What would you like to purchase?");
            Console.WriteLine("Please select what flower you would like: "); 
            Console.WriteLine("1. Rose");
        
            Console.WriteLine("2. Daisy");

            Console.WriteLine("3. Sunflower");

            Console.WriteLine("4. Daffodil");

            Console.WriteLine("5. Tulip");

            Console.WriteLine("6. Lily"); 

            var flowerchoice = int.Parse(Console.ReadLine()); 
            if(flowerchoice == 1)
            {
        
                using (var context = new Flowers.ConsoleApp.Entities.FlowersContext())
                {
                var row = context.Product.First();
                    Console.WriteLine("Thank you for purchasing a " + row.ProductName +". Your total is $"+  row.ProductPrice );
                };    


                using (var context = new Flowers.ConsoleApp.Entities.FlowersContext())
                {
                var newOrder = new Flowers.ConsoleApp.Entities.Order{
                OrderTotal = 4.99M,
                StoreId = 1,
                SaleDate = DateTime.Now
                };

                context.Order.Add(newOrder);
                context.SaveChanges();
                }
                
            }
            else if (flowerchoice == 2)
            {
                using (var context = new Flowers.ConsoleApp.Entities.FlowersContext())
                {
                var row = context.Product.Find(2);
                    Console.WriteLine("Thank you for purchasing a " + row.ProductName +". Your total is $"+  row.ProductPrice );
                    DateTime orderdate = DateTime.Now;
                }

                using (var context = new Flowers.ConsoleApp.Entities.FlowersContext())
                {
                var newOrder = new Flowers.ConsoleApp.Entities.Order{
                OrderTotal = 1.99M,
                StoreId = 1,
                SaleDate = DateTime.Now
                };

                context.Order.Add(newOrder);
                context.SaveChanges();
                }
            }
            else if (flowerchoice == 3)
            {
                using (var context = new Flowers.ConsoleApp.Entities.FlowersContext())
                {
                var row = context.Product.Find(3);
                    Console.WriteLine("Thank you for purchasing a " + row.ProductName +". Your total is $"+  row.ProductPrice );
                    DateTime orderdate = DateTime.Now;
                }
                using (var context = new Flowers.ConsoleApp.Entities.FlowersContext())
                {
                var newOrder = new Flowers.ConsoleApp.Entities.Order{
                OrderTotal = 3.99M,
                StoreId = 1,
                SaleDate = DateTime.Now
                };

                context.Order.Add(newOrder);
                context.SaveChanges();
                }
            }
            else if (flowerchoice == 4)
            {
                using (var context = new Flowers.ConsoleApp.Entities.FlowersContext())
                {
                var row = context.Product.Find(4);
                    Console.WriteLine("Thank you for purchasing a " + row.ProductName +". Your total is $"+  row.ProductPrice );
                    DateTime orderdate = DateTime.Now;
                }
                using (var context = new Flowers.ConsoleApp.Entities.FlowersContext())
                {
                var newOrder = new Flowers.ConsoleApp.Entities.Order{
                OrderTotal = 0.99M,
                StoreId = 1,
                SaleDate = DateTime.Now
                };

                context.Order.Add(newOrder);
                context.SaveChanges();
                }
            }
            else if (flowerchoice == 5)
            {
                using (var context = new Flowers.ConsoleApp.Entities.FlowersContext())
                {
                var row = context.Product.Find(5);
                    Console.WriteLine("Thank you for purchasing a " + row.ProductName +". Your total is $"+  row.ProductPrice );
                    DateTime orderdate = DateTime.Now;
                }
                using (var context = new Flowers.ConsoleApp.Entities.FlowersContext())
                {
                var newOrder = new Flowers.ConsoleApp.Entities.Order{
                OrderTotal = 2.99M,
                StoreId = 1,
                SaleDate = DateTime.Now
                };

                context.Order.Add(newOrder);
                context.SaveChanges();
                }
            }
            else if (flowerchoice == 6)
            {
                using (var context = new Flowers.ConsoleApp.Entities.FlowersContext())
                {
                var row = context.Product.Find(6);
                    Console.WriteLine("Thank you for purchasing a " + row.ProductName +". Your total is $"+  row.ProductPrice );
                    DateTime orderdate = DateTime.Now;
                }
                using (var context = new Flowers.ConsoleApp.Entities.FlowersContext())
                {
                var newOrder = new Flowers.ConsoleApp.Entities.Order{
                OrderTotal = 3.99M,
                StoreId = 1,
                SaleDate = DateTime.Now
                };

                context.Order.Add(newOrder);
                context.SaveChanges();
                }
            }
            else
            {
                // method calls itself in order to restart menu 
                Console.WriteLine("Sorry, invalid option choice. Press 1 to try again, or 2 to quit.");
                var input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    AddOrder(); 
                }
                else
                {
                    Quit();
                }
                
            }

        }
        public static void ReadStore()
        {
            Console.WriteLine("To see store addresses, please select a state");
            Console.WriteLine("1. Texas");
            Console.WriteLine("2. New York");
            var input = int.Parse(Console.ReadLine()); 

            if(input == 1)
            {
                using (var context = new Flowers.ConsoleApp.Entities.FlowersContext())
                {
                    var row = context.Store.First();
                    Console.WriteLine(row.Address +" "+  row.City +" "+ row.State +" "+ row.PostalCode);
                }
            }
            else 
            {
                using (var context = new Flowers.ConsoleApp.Entities.FlowersContext())
                {
                var row = context.Store.Find(2);
                    Console.WriteLine(row.Address +" "+  row.City +" "+ row.State +" "+ row.PostalCode);
                }
            }
        }
        public static void ReadInventory()
        {
            Console.WriteLine("To see the inventory, please select a store location: ");
            Console.WriteLine("1. Texas");
            Console.WriteLine("2. New York"); 
            var input = int.Parse(Console.ReadLine()); 

           if(input == 1)
            {
                using (var context = new Flowers.ConsoleApp.Entities.FlowersContext())
                {
                    var row = context.Inventory.First();
                    Console.WriteLine(row.ProductId +" "+  row.InventoryCount );
                }
            }
            else 
            {
                using (var context = new Flowers.ConsoleApp.Entities.FlowersContext())
                {
                var row = context.Inventory.Find(2);
                    Console.WriteLine(row.ProductId +" "+  row.InventoryCount );
                }
            }

        }
    }
}
