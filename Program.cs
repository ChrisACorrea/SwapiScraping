using SwapiScraping;
using SwapiScraping.Context;
using SwapiScraping.Models;
using SwapiScraping.SwapiModels;

var rootApiUrl = "https://swapi.py4e.com/api/";
using var db = new DatabaseContext();

var jsons = new Dictionary<string, string>();

var peopleData = await new SwapiService<SWPeople>().GetData(rootApiUrl + "people");
var peopleDataConverted = peopleData.ConvertAll(item => (Character)item);

var filmsData = await new SwapiService<SWFilm>().GetData(rootApiUrl + "films");
var filmsDataConverted = filmsData.ConvertAll(item => (Movie)item);

var planetsData = await new SwapiService<SWPlanet>().GetData(rootApiUrl + "planets");
var planetsDataConverted = planetsData.ConvertAll(item => (Planet)item);

var starshipsData = await new SwapiService<SWStarship>().GetData(rootApiUrl + "starships");
var starshipsDataConverted = starshipsData.ConvertAll(item => (Starship)item);

var vehiclesData = await new SwapiService<SWVehicle>().GetData(rootApiUrl + "vehicles");
var vehiclesDataConverted = vehiclesData.ConvertAll(item => (Vehicle)item);

foreach (var character in peopleDataConverted)
{
	foreach (var swId in character.MoviesSwIds)
	{
		character.Movies.Add(filmsDataConverted.Find(f => f.SwId == swId));
	}

	character.Planet = planetsDataConverted.Find(p => p.SwId == character.PlanetSwId);
	character.PlanetId = character.Planet.Id;
	character.UpdatedAt = DateTime.Now;
}

foreach (var movie in filmsDataConverted)
{
	foreach (var swId in movie.CharactersSwIds)
	{
		movie.Characters.Add(peopleDataConverted.Find(f => f.SwId == swId));
	}

	foreach (var swId in movie.PlanetsSwIds)
	{
		movie.Planets.Add(planetsDataConverted.Find(f => f.SwId == swId));
	}

	foreach (var swId in movie.VehiclesSwIds)
	{
		movie.Vehicles.Add(vehiclesDataConverted.Find(f => f.SwId == swId));
	}

	foreach (var swId in movie.StarshipsSwIds)
	{
		movie.Starships.Add(starshipsDataConverted.Find(f => f.SwId == swId));
	}
	movie.UpdatedAt = DateTime.Now;

}

foreach (var planet in planetsDataConverted)
{
	foreach (var swId in planet.CharactersSwIds)
	{
		planet.Characters.Add(peopleDataConverted.Find(f => f.SwId == swId));
	}

	foreach (var swId in planet.MoviesSwIds)
	{
		planet.Movies.Add(filmsDataConverted.Find(f => f.SwId == swId));
	}
	planet.UpdatedAt = DateTime.Now;

}

foreach (var starship in starshipsDataConverted)
{

	foreach (var swId in starship.MoviesSwIds)
	{
		starship.Movies.Add(filmsDataConverted.Find(f => f.SwId == swId));
	}
	starship.UpdatedAt = DateTime.Now;

}

foreach (var vehicle in vehiclesDataConverted)
{

	foreach (var swId in vehicle.MoviesSwIds)
	{
		vehicle.Movies.Add(filmsDataConverted.Find(f => f.SwId == swId));
	}
	vehicle.UpdatedAt = DateTime.Now;

}

db.Characters.AddRange(peopleDataConverted);
db.Movies.AddRange(filmsDataConverted);
db.Planets.AddRange(planetsDataConverted);
db.Starships.AddRange(starshipsDataConverted);
db.Vehicles.AddRange(vehiclesDataConverted);
db.SaveChanges();

System.Console.WriteLine("ACABOOOOOOOOUUUUUUUUUU!!!");