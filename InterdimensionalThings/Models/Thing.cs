using System;
namespace InterdimensionalThings.Models
{
    public class Thing
    {
        public int      Id            { get; set; }
        public string   Name          { get; set; }
        public string   Description   { get; set; }
        public decimal? Price         { get; set; }
        public string   ImagePath     { get; set; }
        public string   Category      { get; set; }
        public string   Quality       { get; set; }
        public int      ShippingDays  { get; set; }
        public string   Maker         { get; set; }
    }
}
