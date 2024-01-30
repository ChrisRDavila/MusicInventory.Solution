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

    public ActionResult Create()
    {
      ViewBag.ArtistId = new SelectList(_db.Artists, "ArtistId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Album album)
    {
      if (album.ArtistId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Albums.Add(album);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Album thisAlbum = _db.Albums
                          .Include(album => album.Artist)
                          .FirstOrDefault(album => album.AlbumId == id);
      return View(thisAlbum);
    }
  
    public ActionResult Edit(int id)
    {
      Album thisAlbum = _db.Albums.FirstOrDefault(album => album.AlbumId == id);
      ViewBag.ArtistId = new SelectList(_db.Artists, "ArtistId", "Name");
      return View(thisAlbum);
    }

    [HttpPost]
    public ActionResult Edit(Album album)
    {
      _db.Albums.Update(album);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Album thisAlbum = _db.Albums.FirstOrDefault(album => album.AlbumId == id);
      return View(thisAlbum);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Album thisAlbum = _db.Albums.FirstOrDefault(album => album.AlbumId == id);
      _db.Albums.Remove(thisAlbum);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
