using Microsoft.AspNetCore.Mvc;
using template.Models;

namespace template.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View("Index", templateModel.GetString());
    }
  }
}
