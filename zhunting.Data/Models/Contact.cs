using System;
using System.Collections.Generic;
using System.Text;

namespace zhunting.Data.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Title { get; set; }
    }
}
