using System;

namespace ArrangementsAnge.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new ArrangementsAnge.Library();
            var customer1 = new Customer();
            var customer2 = new NewCustomer();
            var product1 = new Product();
            var order1 = new Order();
            var order2 = new OrderHistory();

            bool leave = false;
            while (!leave)
            {

                Console.WriteLine("Welcome to Arrangements by Ange!");
                Console.WriteLine("Please select an option below: ");
                Console.WriteLine("i.e type 1 for option one");

                 // user can log in by name (reading from customer DbSet/table) :
                Console.WriteLine("1. Log in as an existing customer");

                // user can register a new customer (writing to customer DbSet/table) :
                Console.WriteLine("2. Log in as a new customer");

                // user can see (e.g.) a list of products available at a given store (reading from several DbSets/tables) :
                Console.WriteLine("3. See flowers available");

                // user can place an order (reading and writing several DbSets/tables) :
                Console.WriteLine("4. Place an order for a new flower arrangement"); 

                 // user can view past order history
                Console.WriteLine("5. View past order history");

                var UserInput = Console.ReadLine();
                var choice = Int32.Parse(UserInput);

                if (choice == 1)
                {
               // existing customer class 
                 }
                else if (choice == 2)
                {
                // new customer class
                }
                else if (choice == 3)
                {
                // inventory list
                 }
                else if (choice == 4)
                {
              // place a new order 
                }
                 else if (choice == 5)
                {
                // view past order history
                }
                else 
                {
                Console.WriteLine("Invalid option choice!");
                leave = true;
                }

            }
        }
    }
}
