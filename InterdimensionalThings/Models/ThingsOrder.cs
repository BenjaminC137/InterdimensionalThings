using System;
using System.Collections.Generic;

namespace InterdimensionalThings.Models
{
    public class ThingsOrder
    {
        public ThingsOrder()
        {
            this.ThingsOrderThings = new HashSet<ThingsOrderThing>();
        }
        public Guid ID { get; set; }
        public string Email { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
        public ICollection<ThingsOrderThing> ThingsOrderThings { get; set; }
    }

    public class ThingsOrderThing{
        
        public Guid ID { get; set; }
        public ThingsOrder ThingsOrder { get; set; }
        public Guid ThingsOrderID { get; set; }
        public string ThingName { get; set; }
        public string ThingDescription { get; set; }
        public decimal ThingPrice { get; set; }
        public int? ThingID { get; set; }
        public int Quantity { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
    }
}
