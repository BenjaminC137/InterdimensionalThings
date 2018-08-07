using System;
using System.Collections.Generic;
namespace InterdimensionalThings.Models

{
    public class ThingCartThing
    {

        public ThingCartThing()
        {
            this.ThingCartThings = new HashSet<ThingCartThing>();
        }

        public int          ID { get; set; }
        public ThingCart    ThingCart { get; set; }
        public int          ThingCartID { get; set; }
        public Thing        Thing { get; set; }
        public int          ThingID { get; set; }
        public int?         Quantity { get; set; }
        public DateTime?    DateCreated { get; set; }
        public DateTime?    DateLastModified { get; set; }
        public ICollection<ThingCartThing> ThingCartThings { get; set; }
    }
}
