using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MusicInventory.Models;
using System.Collections.Generic;
using System.Linq;

namespace MusicInventory.Controllers
{
  public class ArtistsController : Controller
  {
    private readonly MusicInventoryContext _db;

    public ArtistsController(MusicInventoryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Artist> model = _db.Artists
      .ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Artist artist)
    {
      _db.Artists.Add(artist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Artist thisArtist = _db.Artists
      .Include(artist => artist.Albums)
      .FirstOrDefault(artist => artist.ArtistId == id);
      return View(thisArtist);
    }

    public ActionResult Edit(int id)
    {
      Artist thisArtist = _db.Artists.FirstOrDefault(artist => artist.ArtistId == id);
      return View(thisArtist);
    }

    [HttpPost]
    public ActionResult Edit(Artist artist)
    {
      _db.Artists.Update(artist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Artist thisArtist = _db.Artists.FirstOrDefault(artist => artist.ArtistId == id);
      return View(thisArtist);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Artist thisArtist = _db.Artists.FirstOrDefault(artist => artist.ArtistId == id);
      _db.Artists.Remove(thisArtist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}