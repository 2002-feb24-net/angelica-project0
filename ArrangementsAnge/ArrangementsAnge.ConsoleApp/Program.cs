using System;

namespace ArrangementsAnge.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        static void Customer()
        {
            Console.WriteLine("Welcome to Arrangements by Ange!");
            Console.WriteLine("Please select an option below: ");
            Console.WriteLine("i.e type 1 for option one");
            Console.WriteLine("1. Place a new order");
            Console.WriteLine("2. View your current order(s)");
            Console.WriteLine("3. Previous order history");
            Console.WriteLine("4. Store locations"); 

            var UserInput = Console.ReadLine();
            var choice = Int32.Parse(UserInput);

            if (choice == 1)
            {
               // run new order class/methods
            }
            else if (choice == 2)
            {
                // run current order class/methods
            }
            else if (choice == 3)
            {
                // display order history
            }
            else if (choice == 4)
            {
                Console.WriteLine("Our primary location is in: ");
                Console.WriteLine("Arlington, TX"); 
                Console.WriteLine("Our other location is in: ");
                Console.WriteLine("New York, NY"); 
            }
            else 
            {
                Console.WriteLine("Invalid option choice!");
                // need something here to restart loop

            }
        }
    }
}
