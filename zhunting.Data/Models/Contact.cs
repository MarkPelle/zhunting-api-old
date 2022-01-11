using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace zhunting.Data.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public Title Title { get; set; }
    }
}
