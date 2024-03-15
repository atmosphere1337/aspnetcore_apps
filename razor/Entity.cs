using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class CityContext : DbContext
{
    public DbSet<City> Cities { get; set; }
    public string DbPath { get; }
    public CityContext()
    {   
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "City.db");
    }   
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}


public class City
{
    public int CityId { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public int Population { get; set; }
}

