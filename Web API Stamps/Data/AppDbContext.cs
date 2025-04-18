using API_upload.Models;
using Microsoft.EntityFrameworkCore;
using Web_API_Stamps.Models;

namespace API_upload.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Stamp> Stamps { get; set; }

        public DbSet<ImageData> ImagesData { get; set; }

        public DbSet<ThumbnailData> ThumbnailsData { get; set; }

        public DbSet<StampCategory> Categories { get; set; } 
    }
}
