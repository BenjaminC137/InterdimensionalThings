using System;
using System.Collections.Generic;


namespace InterdimensionalThings.Models
{
    public class ThingCart
    {
        public ThingCart()
        {
            this.Things = new HashSet<Thing>();
        }
            
    public int ID { get; set; }
    public int Quantity { get; set; }
    public ICollection<Thing> Things { get; set; }
}
}
