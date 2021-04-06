using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace zhunting.Data.Models
{
    public class Animal
    {
        public Guid Id { get; set; }
        public string AnimalName { get; set; }
        public double PriceInHuf { get; set; }
        public double PriceInEur { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public Zone Zone { get; set; }
        public AnimalImage Image { get; set; }
    }
}
