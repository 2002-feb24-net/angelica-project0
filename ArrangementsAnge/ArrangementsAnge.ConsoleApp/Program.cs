using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using ArrangementsAnge.Library;


namespace ArrangementsAnge.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ArrangementsAngeContext>();
            optionsBuilder.UseSqlServer(SecretConfig.connectionString)
            using (var db = new ArrangementsAngeContext(optionsBuilder.Options))
            {
                
            }


        }
            
    }          
}



// var menu = new ArrangementsAnge.Library();
            // var customer1 = new Customer();
            // var customer2 = new NewCustomer();
            // var product1 = new Product();
            // var order1 = new Order();
            // var order2 = new OrderHistory();

// protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer(SecretConfig.connectionString);
        // }
// var optionsBuilder = new DbContextOptionsBuilder<ArrangementsAngeContext>();
            // using (var db = new ArrangementsAngeContext(optionsBuilder.Options));           

            

          