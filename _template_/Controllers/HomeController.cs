using Microsoft.AspNetCore.Mvc;
using _template_.Models;

namespace _template_.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View("Index", _template_Model.GetString());
    }
  }
}
