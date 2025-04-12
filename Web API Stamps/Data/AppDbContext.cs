using API_upload.Models;
using Microsoft.EntityFrameworkCore;

namespace API_upload.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Stamp> Stamps { get; set; }

        public DbSet<ImageData> ImagesData { get; set; }

        public DbSet<ThumbnailData> ThumbnailsData { get; set; }
    }
}
