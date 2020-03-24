using System;
using System.Collections.Generic;

namespace ArrangementsAnge.Data.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Sale = new HashSet<Sale>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        public virtual ICollection<Sale> Sale { get; set; }
    }
}
