using System;
using System.Collections.Generic;

namespace InterdimensionalThings.Models
{
    public class ThingCategory
    {
        public ThingCategory()
        {
            this.Things = new HashSet<Thing>();
        }

        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }

        public ICollection<Thing> Things { get; set; }

      
    }
}