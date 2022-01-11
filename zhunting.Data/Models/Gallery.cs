using System;
using System.Collections.Generic;
using System.Text;

namespace zhunting.Data.Models
{
    public class Gallery
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<GalleryImage> GalleryImages { get; set; }
        public bool IsDeleted { get; set; }
    }
}
