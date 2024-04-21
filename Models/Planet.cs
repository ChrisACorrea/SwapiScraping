using SwapiScraping.SwapiModels;

namespace SwapiScraping.Models;

public class Planet
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string RotationPeriod { get; set; } = string.Empty;
	public string OrbitalPeriod { get; set; } = string.Empty;
	public string Diameter { get; set; } = string.Empty;
	public string Climate { get; set; } = string.Empty;
	public string Gravity { get; set; } = string.Empty;
	public string Terrain { get; set; } = string.Empty;
	public string SurfaceWater { get; set; } = string.Empty;
	public string Population { get; set; } = string.Empty;
	public IList<int> Characters { get; set; } = [];
	public IList<int> Movies { get; set; } = [];

	public static implicit operator Planet(SWPlanet swPlanet)
	{
		var planet = new Planet()
		{
			Name = swPlanet.Name,
			RotationPeriod = swPlanet.RotationPeriod,
			OrbitalPeriod = swPlanet.OrbitalPeriod,
			Diameter = swPlanet.Diameter,
			Climate = swPlanet.Climate,
			Gravity = swPlanet.Gravity,
			Terrain = swPlanet.Terrain,
			SurfaceWater = swPlanet.SurfaceWater,
			Population = swPlanet.Population,
			Id = Helper.GetIdFromUrl(swPlanet.Url)
		};

		foreach (var character in swPlanet.Residents)
		{
			planet.Characters.Add(Helper.GetIdFromUrl(character));
		}

		foreach (var film in swPlanet.Films)
		{
			planet.Movies.Add(Helper.GetIdFromUrl(film));
		}

		return planet;
	}
}
