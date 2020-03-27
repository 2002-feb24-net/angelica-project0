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
            bool loop = true;
            List<string> currentuser = new List<string>();
            while(loop)
            {
                
                int userOption = Menu();
                if (userOption == 1)
                {
                    // creates a new customer in the db
                    currentuser.Add(AddCustomer());
                }
                else if (userOption == 2)
                {
                    // reads an existing customer in the db
                   
                    currentuser.Add(ReadCustomer());
                }
                else if (userOption == 3)
                {
                    // creates a new order for a product
                    
                    AddOrder(currentuser[0]);
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
                else if (userOption == 6)
                {
                    ReadOrder(currentuser[0]);
                }
               
                else
                {
                    loop = false;
                    //exits
                }
            }
        Console.WriteLine("Goodbye! Come back soon.");
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
                Console.WriteLine("6. View order history");
                Console.WriteLine("7. Exit"); 

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

        public static string AddCustomer()
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
            return userName;

        }

        public static string ReadCustomer()
        {
            System.Console.WriteLine("Log in as an existing customer");
            System.Console.WriteLine("Please enter your username: ");
            string userName = Console.ReadLine();

            
            using (var context = new Flowers.ConsoleApp.Entities.FlowersContext())
            {
                
                    try
                    {
                        var user = context.Customer.First(c => c.Username == userName);
                        return user.Username;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        Console.WriteLine("Invalid username");
                        return ReadCustomer();
                    }

            };
            return null;
            

        }

        public static void AddOrder(string currentuser)
        {
            Console.WriteLine("What store would you like to purchase from?");
            Console.WriteLine("Please select a location: ");
            Console.WriteLine("1. Texas");
            Console.WriteLine("2. New York");
            var storechoice = int.Parse(Console.ReadLine());
            
            bool done = false;
            Dictionary<string,double> cart = new Dictionary<string, double>();
            double price = 0;
            string flower = "";

            while (!done)
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
            
            using (var context = new Flowers.ConsoleApp.Entities.FlowersContext())
            {
                var row = new Product();

                while(row.ProductName == null)
                {
                    try
                    {
                        row = context.Product.First(p => p.ProductId == flowerchoice);
                        price = Convert.ToDouble(row.ProductPrice);
                        flower = row.ProductName;

                        Console.WriteLine("Thank you for purchasing a " + row.ProductName);
                        Console.ReadLine();
                        // here we need to decrement the inventory count as well as add a new order to the orders table with appropriate data
                        var inventoryobject = context.Inventory.First(c => c.ProductId == flowerchoice);
                        inventoryobject.InventoryCount = inventoryobject.InventoryCount - 1;
                        context.Update(inventoryobject);
                        context.SaveChanges();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        Console.WriteLine("Invalid input");
                        break;
                    }
                }
                
            };

            cart.Add(flower, price);
            Console.WriteLine("Would you like to purchase another flower? y/n");
            string moreflower = Console.ReadLine();
            if (moreflower != "y")
            {
                done = true;
            }

            }

            DateTime now = DateTime.Now;
            using (var context = new Flowers.ConsoleApp.Entities.FlowersContext())
            {
             double total = 0;
             foreach(var item in cart)
             {
                total = total + item.Value;
             }
                Console.WriteLine("Your total is " + total);
                Console.ReadLine();
                var getid = context.Customer.First(g => g.Username == currentuser).CustomerId;

                var newOrder = new Order(){
                    StoreId = storechoice,
                    SaleDate = now,
                    CustomerId = getid,
                    OrderTotal = Convert.ToDecimal(total)
                    
                };
                        context.Order.Add(newOrder);
                        context.SaveChanges();

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

            if (input == 1)
            {
                using (var context = new Flowers.ConsoleApp.Entities.FlowersContext())
                {
                        var row1 = context.Inventory.Find(1);
                        Console.WriteLine("Rose amount: "+  row1.InventoryCount );

                        var row2 = context.Inventory.Find(2);
                        Console.WriteLine("Daisy amount: "+  row2.InventoryCount );

                        var row3 = context.Inventory.Find(3);
                        Console.WriteLine("Sunflower amount: "+  row3.InventoryCount );

                        var row4 = context.Inventory.Find(4);
                        Console.WriteLine("Daffodil amount: "+  row4.InventoryCount );

                        var row5 = context.Inventory.Find(5);
                        Console.WriteLine("Tulip amount: "+  row5.InventoryCount );

                        var row6 = context.Inventory.Find(6);
                        Console.WriteLine("Lily amount: "+  row6.InventoryCount );
                }        
                        

            }
            else 
            {
                using (var context = new Flowers.ConsoleApp.Entities.FlowersContext())
                {
                        var row1 = context.Inventory.Find(7);
                        Console.WriteLine("Rose amount: "+  row1.InventoryCount );

                        var row2 = context.Inventory.Find(8);
                        Console.WriteLine("Daisy amount: "+  row2.InventoryCount );

                        var row3 = context.Inventory.Find(9);
                        Console.WriteLine("Sunflower amount: "+  row3.InventoryCount );

                        var row4 = context.Inventory.Find(10);
                        Console.WriteLine("Daffodil amount: "+  row4.InventoryCount );

                        var row5 = context.Inventory.Find(11);
                        Console.WriteLine("Tulip amount: "+  row5.InventoryCount );

                        var row6 = context.Inventory.Find(12);
                        Console.WriteLine("Lily amount: "+  row6.InventoryCount );
                }        
                        
            }
                
            

        }

        public static void ReadOrder(string currentuser)
        {

        }
    }
}
