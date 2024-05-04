using SwapiScraping.SwapiModels;

namespace SwapiScraping.Models;

public class Planet : Model
{
	public string Name { get; set; } = string.Empty;
	public string RotationPeriod { get; set; } = string.Empty;
	public string OrbitalPeriod { get; set; } = string.Empty;
	public string Diameter { get; set; } = string.Empty;
	public string Climate { get; set; } = string.Empty;
	public string Gravity { get; set; } = string.Empty;
	public string Terrain { get; set; } = string.Empty;
	public string SurfaceWater { get; set; } = string.Empty;
	public string Population { get; set; } = string.Empty;
	public ICollection<Character> Characters { get; set; } = [];
	public ICollection<Movie> Movies { get; set; } = [];
	public ICollection<int> CharactersSwIds { get; set; } = [];
	public ICollection<int> MoviesSwIds { get; set; } = [];

	public static implicit operator Planet(SWPlanet swPlanet)
	{
		var planet = new Planet()
		{
			Id = Guid.NewGuid(),
			Name = swPlanet.Name,
			RotationPeriod = swPlanet.RotationPeriod,
			OrbitalPeriod = swPlanet.OrbitalPeriod,
			Diameter = swPlanet.Diameter,
			Climate = swPlanet.Climate,
			Gravity = swPlanet.Gravity,
			Terrain = swPlanet.Terrain,
			SurfaceWater = swPlanet.SurfaceWater,
			Population = swPlanet.Population,
			SwId = Helper.GetIdFromUrl(swPlanet.Url),
			CreatedAt = DateTime.Now.ToUniversalTime(),
			UpdatedAt = DateTime.Now.ToUniversalTime()
		};

		foreach (var character in swPlanet.Residents)
		{
			planet.CharactersSwIds.Add(Helper.GetIdFromUrl(character));
		}

		foreach (var film in swPlanet.Films)
		{
			planet.MoviesSwIds.Add(Helper.GetIdFromUrl(film));
		}

		DateTime.SpecifyKind(planet.CreatedAt, DateTimeKind.Utc);
		DateTime.SpecifyKind(planet.UpdatedAt, DateTimeKind.Utc);

		return planet;
	}
}
