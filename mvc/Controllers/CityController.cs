using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;

namespace mvc.Controllers
{
    public class CityController : Controller
    {
        // GET: CityController
        public ActionResult Index()
        {
            ViewData["context"] = "Viewdata";
            ViewBag.context = "ViewBag";
            var wrp = new Wrapper();
            wrp.Msg = "ViewModel strongly typed";
            return View(wrp);
        }
    }
    public class Wrapper {
        public string Msg {get; set;}
    }
}
