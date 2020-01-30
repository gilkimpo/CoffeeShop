using System;
using System.Collections.Generic;

namespace CoffeShop.Models
{
    public partial class Items
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public int? Id { get; set; }
    }
}
