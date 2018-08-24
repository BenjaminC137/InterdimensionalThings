using System;

namespace InterdimensionalThings.Models
{
    public class ThingsOrderThing
    {
        public Guid ID { get; set; }

        public ThingsOrder Order { get; set; }

        public Guid ThingOrderID { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal ProductPrice { get; set; }

        public int? ProductID { get; set; }

        public int Quantity { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateLastModified { get; set; }
        
        
    }
}
