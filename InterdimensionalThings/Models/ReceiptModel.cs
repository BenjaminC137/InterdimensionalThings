using System;
namespace InterdimensionalThings.Models
{
    public class ReceiptModel
    {
        public ThingsOrder ThingsOrder { get; set; }
        public Thing[] Things { get; set; }
        public CheckoutModel CheckoutModel { get; set; }
        public ThingCart ThingCart { get; set; }

        public ReceiptModel()
        {
        }
    }
}
