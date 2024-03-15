using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace razor.Pages;
[IgnoreAntiforgeryToken]
public class IndexModel : PageModel
{
    public List<City> context {get; set;}
    public void OnGet()
    {
    }
    public IActionResult OnPost() {
        Console.WriteLine("default");
        return Content("default");       
    }
    public IActionResult OnPostCreate(string name, string country, int population)
    {
        var db = new CityContext();
        db.Add(new City{ Name = name, Country = country, Population = population});
        db.SaveChanges();
        return Redirect("/index");      
    }
    public IActionResult OnPostUpdate(int id ,string city, string country, int population)
    {
        var db = new CityContext();
        var foundCity = db.Cities.Where(x => x.CityId == id).SingleOrDefault();
        if (foundCity != null) {
            foundCity.Name = city;
            foundCity.Country = country;
            foundCity.Population = population;
            db.SaveChanges();
        }
         return Redirect("/index");     
    }
    public IActionResult OnPostDelete(int id)
    {
        var db = new CityContext();
        var city = db.Cities.Where(x => x.CityId == id).SingleOrDefault();
        if (city != null) {
            db.Remove(city);
            db.SaveChanges();
        }
        return Redirect("/index");
        
    }
}
