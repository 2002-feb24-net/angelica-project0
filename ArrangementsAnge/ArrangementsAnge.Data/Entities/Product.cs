using System;
using System.Collections.Generic;

namespace ArrangementsAnge.Data.Entities
{
    public partial class Product
    {
        public Product()
        {
            Inventory = new HashSet<Inventory>();
            SaleLine = new HashSet<SaleLine>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<SaleLine> SaleLine { get; set; }
    }
}
