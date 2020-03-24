using System;
using Microsoft.EntityFrameworkCore;
using Flowers.Data;
using Flowers.ConsoleApp.Entities;

namespace Flowers.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int userOption = Menu();
            if(userOption == 1)
            {
                AddCustomer();
            }
           
            //  var contextOptions = new DbContextOptionsBuilder<FlowersContext>();
            //     // .UseSqlServer(SecretConfiguration.ConnectionString)
            //     // .Options;

            // using (var context = new FlowersContext(contextOptions))
            // {
            //      var customer = new Customer{
            //     FirstName = "John",
            //     LastName = "Smith"
            //      };

            //     context.Customer.Add(customer);
            //     context.SaveChanges();
            // }   

        }

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

        }
    }
}
