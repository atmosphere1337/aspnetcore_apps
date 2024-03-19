using Microsoft.EntityFrameworkCore;

public class CityContext : DbContext {
    public DbSet<City> Cities {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseMySql("server=localhost;user=root;password=1337;database=ef", new MySqlServerVersion("8.0.2"))
               .LogTo(Console.WriteLine, LogLevel.Information)
               .EnableSensitiveDataLogging()
               .EnableDetailedErrors();
    }

}
public class City {
    public int CityId {get; set;}
    public string Name {get; set;}
    public string Country {get; set;}
    public int Population {get; set;}
}