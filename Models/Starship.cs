using SwapiScraping.SwapiModels;

namespace SwapiScraping.Models;

public class Starship
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Model { get; set; } = string.Empty;
	public string Manufacturer { get; set; } = string.Empty;
	public string CostInCredits { get; set; } = string.Empty;
	public string Length { get; set; } = string.Empty;
	public string MaxSpeed { get; set; } = string.Empty;
	public string Crew { get; set; } = string.Empty;
	public string Passengers { get; set; } = string.Empty;
	public string CargoCapacity { get; set; } = string.Empty;
	public string HyperdriveRating { get; set; } = string.Empty;
	public string MGLT { get; set; } = string.Empty;
	public string Consumables { get; set; } = string.Empty;
	public string Class { get; set; } = string.Empty;
	public IList<int> Movies { get; set; } = [];

	public static implicit operator Starship(SWStarship swStarship)
	{
		var starship = new Starship()
		{
			Name = swStarship.Name,
			Model = swStarship.Model,
			Manufacturer = swStarship.Manufacturer,
			CostInCredits = swStarship.CostInCredits,
			Length = swStarship.Length,
			MaxSpeed = swStarship.MaxAtmospheringSpeed,
			Crew = swStarship.Crew,
			Passengers = swStarship.Passengers,
			CargoCapacity = swStarship.CargoCapacity,
			HyperdriveRating = swStarship.HyperdriveRating,
			MGLT = swStarship.MGLT,
			Consumables = swStarship.Consumables,
			Class = swStarship.StarshipClass,
			Id = Helper.GetIdFromUrl(swStarship.Url)
		};

		foreach (var film in swStarship.Films)
		{
			starship.Movies.Add(Helper.GetIdFromUrl(film));
		}

		return starship;
	}
}
