using System;
using System.Collections.Generic;

namespace Flowers.ConsoleApp.Entities
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime SaleDate { get; set; }
        public int StoreId { get; set; }
        public decimal OrderTotal { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
    }
}
