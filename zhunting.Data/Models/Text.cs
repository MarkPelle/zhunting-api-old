using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace zhunting.Data.Models
{
    public class Text
    {
        public Guid Id { get; set; }
        [MaxLength(255)]
        public string Paragraph { get; set; }
    }
}
