using System;
using System.Collections.Generic;
using System.Text;

namespace zhunting.Data.DTOs
{
    public class GalleryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public string [] Images { get; set; }
    }
}
