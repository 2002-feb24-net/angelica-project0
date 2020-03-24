﻿using System;
using System.Collections.Generic;

namespace ArrangementsAnge.Data.Entities
{
    public partial class Store
    {
        public Store()
        {
            Inventory = new HashSet<Inventory>();
            Sale = new HashSet<Sale>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostalCode { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Sale> Sale { get; set; }
    }
}
