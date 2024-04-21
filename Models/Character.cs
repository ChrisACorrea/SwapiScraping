using SwapiScraping.SwapiModels;

namespace SwapiScraping.Models;

public class Character
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Height { get; set; } = string.Empty;
	public string Weight { get; set; } = string.Empty;
	public string HairColor { get; set; } = string.Empty;
	public string SkinColor { get; set; } = string.Empty;
	public string EyeColor { get; set; } = string.Empty;
	public string BirthYear { get; set; } = string.Empty;
	public string Gender { get; set; } = string.Empty;
	public int Planet { get; set; }
	public IList<int> Movies { get; set; } = [];

	public static implicit operator Character(SWPeople people)
	{
		var character = new Character()
		{
			Name = people.Name,
			Height = people.Height,
			Weight = people.Mass,
			HairColor = people.HairColor,
			SkinColor = people.SkinColor,
			EyeColor = people.EyeColor,
			BirthYear = people.BirthYear,
			Gender = people.Gender,
			Planet = Helper.GetIdFromUrl(people.Homeworld),
			Id = Helper.GetIdFromUrl(people.Url)
		};

		foreach (var film in people.Films)
		{
			character.Movies.Add(Helper.GetIdFromUrl(film));
		}

		return character;
	}
}
