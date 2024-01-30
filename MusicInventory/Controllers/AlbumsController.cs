using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MusicInventory.Models;
using System.Collections.Generic;
using System.Linq;

namespace MusicInventory.Controllers
{
  public class AlbumsController : Controller
  {
    private readonly MusicInventoryContext _db;

    public AlbumsController(MusicInventoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Album> model = _db.Albums
      .Include(album => album.Artist)
      .OrderBy(album => album.Title)
      .ToList();
      return View(model);
    }
  }
}
