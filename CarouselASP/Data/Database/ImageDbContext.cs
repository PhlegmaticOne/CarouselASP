using CarouselASP.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarouselASP.Data.Database
{
    public class ImageDbContext : DbContext
    {
        public ImageDbContext(DbContextOptions<ImageDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumImage>().HasData(
                new AlbumImage() { Id = 1, Artist = "Anaal Nathrakh", AlbumName = "Total Fucking Necro", Path = "covers/Anaal Nathrakh - Total Fucking Necro.jpg" },
                new AlbumImage() { Id = 2, Artist = "Arckanum", AlbumName = "Kostogner", Path = "covers/Arckanum - Kostogner.jpg" },
                new AlbumImage() { Id = 3, Artist = "Arckanum", AlbumName = "ÞÞÞÞÞÞÞÞÞÞÞ", Path = "covers/Arckanum - ÞÞÞÞÞÞÞÞÞÞÞ.jpg" },
                new AlbumImage() { Id = 4, Artist = "Austere", AlbumName = "To Lay Like Old Ashes", Path = "covers/Austere - To Lay Like Old Ashes.jpg" },
                new AlbumImage() { Id = 5, Artist = "Cadaveria", AlbumName = "Far Away From Conformity", Path = "covers/Cadaveria - Far Away From Conformity.jpg" }
            );
        }
        public DbSet<AlbumImage> AlbumImages { get; set; }
    }
}
