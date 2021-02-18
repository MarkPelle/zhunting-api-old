using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using zhunting.Data.Models;

namespace zhunting.DataAccess
{
    public class ZhuntingDbContext : DbContext
    {
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Text> Texts { get; set; }
        public ZhuntingDbContext(DbContextOptions<ZhuntingDbContext> options) : base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Gallery>().HasMany(e => e.Images).WithOne(i => i.Gallery);
        }
        public void SeedData(ModelBuilder modelBuilder)
        {
            var gallery = new Gallery()
            {
                Id = Guid.NewGuid(),
                Name = "Test Gallery"
            };

            var image = new Image()
            {
                Id = Guid.NewGuid(),
                Link = "https://thephotostudio.com.au/wp-content/uploads/2017/10/Emily-Ratajkowski-1.jpg",
                GalleryId = gallery.Id
            };

            modelBuilder.Entity<Gallery>().HasData(gallery);
            modelBuilder.Entity<Image>().HasData(image);
        }
    }
}