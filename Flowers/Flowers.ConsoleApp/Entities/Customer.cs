using System;
using System.Collections.Generic;

namespace Flowers.ConsoleApp.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
