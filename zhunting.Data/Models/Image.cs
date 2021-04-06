using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace zhunting.Data.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public Guid GalleryId { get; set; }
        public string Link { get; set; }
        [ForeignKey("GalleryId")]
        
        public Gallery Gallery { get; set; }
        
    }
}