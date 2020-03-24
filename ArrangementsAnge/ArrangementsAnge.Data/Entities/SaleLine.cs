using System;
using System.Collections.Generic;

namespace ArrangementsAnge.Data.Entities
{
    public partial class SaleLine
    {
        public int SaleLineId { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Sale Sale { get; set; }
    }
}
