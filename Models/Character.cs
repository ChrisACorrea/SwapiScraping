using SwapiScraping.SwapiModels;

namespace SwapiScraping.Models;

public class Character : Model
{
	public string Name { get; set; } = string.Empty;
	public string Height { get; set; } = string.Empty;
	public string Weight { get; set; } = string.Empty;
	public string HairColor { get; set; } = string.Empty;
	public string SkinColor { get; set; } = string.Empty;
	public string EyeColor { get; set; } = string.Empty;
	public string BirthYear { get; set; } = string.Empty;
	public string Gender { get; set; } = string.Empty;
	public Guid PlanetId { get; set; }
	public Planet? Planet { get; set; }
	public int PlanetSwId { get; set; }
	public ICollection<Movie> Movies { get; set; } = [];
	public ICollection<int> MoviesSwIds { get; set; } = [];

	public static implicit operator Character(SWPeople people)
	{
		var character = new Character()
		{
			Id = Guid.NewGuid(),
			Name = people.Name,
			Height = people.Height,
			Weight = people.Mass,
			HairColor = people.HairColor,
			SkinColor = people.SkinColor,
			EyeColor = people.EyeColor,
			BirthYear = people.BirthYear,
			Gender = people.Gender,
			PlanetSwId = Helper.GetIdFromUrl(people.Homeworld),
			SwId = Helper.GetIdFromUrl(people.Url),
			CreatedAt = DateTime.Now.ToUniversalTime(),
			UpdatedAt = DateTime.Now.ToUniversalTime()
		};

		foreach (var film in people.Films)
		{
			character.MoviesSwIds.Add(Helper.GetIdFromUrl(film));
		}

		DateTime.SpecifyKind(character.CreatedAt, DateTimeKind.Utc);
		DateTime.SpecifyKind(character.UpdatedAt, DateTimeKind.Utc);

		return character;
	}
}
