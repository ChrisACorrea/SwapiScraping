using SwapiScraping.SwapiModels;

namespace SwapiScraping.Models;

public class Starship : Model
{
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
	public ICollection<Movie> Movies { get; set; } = [];
	public ICollection<int> MoviesSwIds { get; set; } = [];

	public static implicit operator Starship(SWStarship swStarship)
	{
		var starship = new Starship()
		{
			Id = Guid.NewGuid(),
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
			SwId = Helper.GetIdFromUrl(swStarship.Url),
			CreatedAt = DateTime.Now.ToUniversalTime(),
			UpdatedAt = DateTime.Now.ToUniversalTime()
		};

		foreach (var film in swStarship.Films)
		{
			starship.MoviesSwIds.Add(Helper.GetIdFromUrl(film));
		}

		DateTime.SpecifyKind(starship.CreatedAt, DateTimeKind.Utc);
		DateTime.SpecifyKind(starship.UpdatedAt, DateTimeKind.Utc);

		return starship;
	}
}
