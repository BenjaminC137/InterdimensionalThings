using System;
using System.Collections;
using System.Collections.Generic;
namespace InterdimensionalThings.Models
{
    public class Thing
    {
        
        public Thing()
        {
            this.ThingCartThings = new HashSet<ThingCartThing>();
        }
        public ICollection<ThingCartThing> ThingCartThings { get; set; }

        public int           Id                 { get; set; }
        public string        Name               { get; set; }
        public string        Description        { get; set; }
        public decimal?      Price              { get; set; }
        public string        ImagePath          { get; set; }
        public string        Category           { get; set; }
        public string        Quality            { get; set; }
        public int           ShippingDays       { get; set; }
        public string        Maker              { get; set; }
        public DateTime?     DateCreated        { get; set; }
        public DateTime?     DateLastModified   { get; set; }
        public ThingCategory ThingCategory      { get; set; }
        public string        ThingCategoryName  { get; set; }
    }
}
