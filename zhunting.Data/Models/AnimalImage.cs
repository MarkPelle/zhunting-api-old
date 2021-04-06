using System;
using System.Collections.Generic;
using System.Text;

namespace zhunting.Data.Models
{
    public class AnimalImage
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public Guid AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}
