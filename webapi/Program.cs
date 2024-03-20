using System.Net.Mime;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/city", () =>
{
    var db = new CityContext();
    var cities = db.Cities;
    return cities;
});

app.MapGet("/city/{id}", (int id) => {
    var db = new CityContext();
    var existingCity = db.Cities.Where( x => x.CityId == id).SingleOrDefault();
    return existingCity; 
});
app.MapPost("/city", (HttpRequest request) => {    
    var db = new CityContext();
    var newCity = new City {Name = request.Form["Name"], Country = request.Form["Country"], Population = Int32.Parse(request.Form["Population"])};
    db.Add(newCity);
    db.SaveChanges();
    return newCity.CityId.ToString();
});
app.MapDelete("/city/{id}", (int id)  => {
    var db = new CityContext();
    var foundCity = db.Cities.Where(x => x.CityId == id).SingleOrDefault();
    if (foundCity != null) {
        db.Remove(foundCity);
        if (db.SaveChanges() > 0) {
            return Results.StatusCode(204);
        }
    }
    return Results.StatusCode(404);
});
app.MapPut("/city/{id}", (int id, HttpRequest request) => {
    var db = new CityContext();
    var foundCity = db.Cities.Where(x => x.CityId == id).SingleOrDefault();
    if (foundCity != null) {
        foundCity.Name = request.Form["Name"];
        foundCity.Country = request.Form["Country"];
        foundCity.Population = Int32.Parse(request.Form["Population"]);
        db.Update(foundCity);
        db.SaveChanges();
        return Results.StatusCode(201);

    }
    return Results.StatusCode(404);
});


app.Run();
