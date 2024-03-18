using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;

namespace mvc.Controllers
{
    public class CityController : Controller
    {
        // GET: CityController
        public ActionResult Index()
        {
            /*
            ViewData["context"] = "Viewdata";
            ViewBag.context = "ViewBag";
            var wrp = new Wrapper();
            wrp.Msg = "ViewModel strongly typed";
            */
            var db = new CityContext();
            List<City> context = db.Cities.ToList<City>();
            return View(context);
        }
        [HttpPost]
        public ActionResult Create(string Name, string Country, int Population) {
            //return Content($"{Name} {Country} {Population}");
            var db = new CityContext();
            db.Add(new City { Name = Name, Country = Country, Population = Population});
            db.SaveChanges();
            return Redirect("/City");
        }
        [HttpPost]
        public ActionResult Update(int CityId, string Name, string Country, int Population) {
            //return Content($"{CityId} {Name} {Country} {Population}");
            var db = new CityContext();
            var city = db.Cities.Where(x => x.CityId == CityId).SingleOrDefault();
            if (city != null) {
                city.Name = Name;
                city.Country = Country;
                city.Population = Population;
                db.Update(city);
                db.SaveChanges();
            }
            return Redirect("/City");
        }
        [HttpPost]
        public ActionResult Delete(int CityId) {
            //return Content($"{CityId}");
            var db = new CityContext();
            var city = db.Cities.Where( x => x.CityId == CityId).SingleOrDefault();
            if (city != null) {
                db.Remove(city);
                db.SaveChanges();    
            }            
            return Redirect("/City");
        }
    }
    public class Wrapper {
        public string Msg {get; set;}
    }
}
