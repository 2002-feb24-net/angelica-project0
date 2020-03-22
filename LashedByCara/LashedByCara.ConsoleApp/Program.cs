using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using LashedByCara.Library;
using LashedByCara.Library.Models;
using LashedByCara.Library.Repositories;

namespace LashedByCara.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
         

        }

        static void Menu()
        {
            Console.WriteLine("Welcome to Lashed by Cara!");
            Console.WriteLine("Please select an option below: ");
            Console.WriteLine("i.e type 1 for option one");
            Console.WriteLine("1. Book in for a treatment");
            Console.WriteLine("2. Details of your booking");
            Console.WriteLine("3. Past treatments");
            Console.WriteLine("4. Nearest Location"); 

            var UserInput = Console.ReadLine();
            var choice = Int32.Parse(UserInput);

            if (choice == 1)
            {
                // run book in class
            }
            else if (choice == 2)
            {
                // display booking details
            }
            else if (choice == 3)
            {
                // display order history
            }
            else if (choice == 4)
            {
                // display locations
            }
            else 
            {
                Console.WriteLine("Invalid option choice");
                // need something here to restart loop

            }
        }
    }
}
