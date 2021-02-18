using System;
using System.Collections.Generic;
using System.Text;

namespace zhunting.Data.Models
{
    public class Animal
    {
        public Guid Id { get; set; }
        public string AnimalName { get; set; }
        public double PriceInHuf { get; set; }
        public double PriceInEur { get; set; }
        public Zone Zone { get; set; }
    }
}
