using Microsoft.AspNetCore.Mvc;



namespace MusicInventory.Controllers
{
  public class HomeController : Controller
  {
   [HttpGet("/")]
  
    public ActionResult Index() { return View(); }
  }
}