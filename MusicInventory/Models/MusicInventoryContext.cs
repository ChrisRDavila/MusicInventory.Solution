using Microsoft.EntityFrameworkCore;

namespace MusicInventory.Models
{
  public class MusicInventoryContext : DbContext
  {
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Album> Albums { get; set; }

    public MusicInventoryContext(DbContextOptions options) : base(options) { }
  }
}