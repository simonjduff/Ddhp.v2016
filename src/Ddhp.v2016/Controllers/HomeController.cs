using Microsoft.AspNet.Mvc;

namespace Ddhp.v2016.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}