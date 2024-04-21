using System.Text.Json;
using SwapiScraping;
using SwapiScraping.Models;
using SwapiScraping.SwapiModels;

var rootApiUrl = "https://swapi.dev/api/";

var options = new JsonSerializerOptions
{
	PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
	WriteIndented = true,
	MaxDepth = 64
};

var jsons = new Dictionary<string, string>();

var peopleData = await new SwapiService<SWPeople>().GetData(rootApiUrl + "people");
var peopleDataConverted = peopleData.ConvertAll(item => (Character)item);
var peopleResult = JsonSerializer.Serialize(peopleDataConverted, options);
jsons.Add("Characters", peopleResult);

var filmsData = await new SwapiService<SWFilm>().GetData(rootApiUrl + "films");
var filmsDataConverted = filmsData.ConvertAll(item => (Movie)item);
var filmsResult = JsonSerializer.Serialize(filmsDataConverted, options);
jsons.Add("Movie", filmsResult);

var planetsData = await new SwapiService<SWPlanet>().GetData(rootApiUrl + "planets");
var planetsDataConverted = planetsData.ConvertAll(item => (Planet)item);
var planetsResult = JsonSerializer.Serialize(planetsDataConverted, options);
jsons.Add("Planet", planetsResult);

var starshipsData = await new SwapiService<SWStarship>().GetData(rootApiUrl + "starships");
var starshipsDataConverted = starshipsData.ConvertAll(item => (Starship)item);
var starshipsResult = JsonSerializer.Serialize(starshipsDataConverted, options);
jsons.Add("Starships", starshipsResult);

var vehiclesData = await new SwapiService<SWVehicle>().GetData(rootApiUrl + "vehicles");
var vehiclesDataConverted = vehiclesData.ConvertAll(item => (Vehicle)item);
var vehiclesResult = JsonSerializer.Serialize(vehiclesDataConverted, options);
jsons.Add("Vehicles", vehiclesResult);


string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Outputs");
Directory.CreateDirectory(folderPath);
foreach (var item in jsons)
{
	string filePath = Path.Combine(folderPath, $"{item.Key}.json");
	File.WriteAllText(filePath, item.Value);
}