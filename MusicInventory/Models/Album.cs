using System;

namespace MusicInventory.Models
{
  public class Album
  {
    public int AlbumId { get; set; }
    public string Title { get; set; }
    public int Rating { get; set; }
    public DateTime Release { get; set; }
    public int ArtistId { get; set; }
    public Artist Artist { get; set; }
  }
}