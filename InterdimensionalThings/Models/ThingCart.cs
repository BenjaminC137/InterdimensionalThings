using System;
using System.Collections.Generic;


namespace InterdimensionalThings.Models
{
    public class ThingCart
    {


        public ThingCart()
        {
            //Not really necassary for this, but often helpful for Unit Tests:
            this.ThingCartThings = new HashSet<ThingCartThing>();
        }

        public int ID { get; set; }



        //ICollection<BeachProduct> is a bit more "flexible" than BeachProduct[]; 
        //this is going to help in subsequent work to move this to a database
        public ICollection<ThingCartThing> ThingCartThings { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateLastModified { get; set; }




    //    public ThingCart()
    //    {
    //        this.Things = new HashSet<Thing>();
    //    }
            
    //public int ID { get; set; }
    //public int Quantity { get; set; }
    //public ICollection<Thing> Things { get; set; }
    }
}
