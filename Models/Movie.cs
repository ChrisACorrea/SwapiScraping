using SwapiScraping.SwapiModels;

namespace SwapiScraping.Models;

public class Movie : Model
{
	public string Title { get; set; } = string.Empty;
	public int Episode { get; set; }
	public string OpeningCrawl { get; set; } = string.Empty;
	public string Director { get; set; } = string.Empty;
	public string Producer { get; set; } = string.Empty;
	public DateTime ReleaseDate { get; set; }
	public ICollection<Character> Characters { get; set; } = [];
	public ICollection<Planet> Planets { get; set; } = [];
	public ICollection<Vehicle> Vehicles { get; set; } = [];
	public ICollection<Starship> Starships { get; set; } = [];
	public ICollection<int> CharactersSwIds { get; set; } = [];
	public ICollection<int> PlanetsSwIds { get; set; } = [];
	public ICollection<int> VehiclesSwIds { get; set; } = [];
	public ICollection<int> StarshipsSwIds { get; set; } = [];

	public static implicit operator Movie(SWFilm film)
	{
		var movie = new Movie()
		{
			Id = Guid.NewGuid(),
			Title = film.Title,
			Episode = film.EpisodeId,
			OpeningCrawl = film.OpeningCrawl,
			Director = film.Director,
			Producer = film.Producer,
			ReleaseDate = film.ReleaseDate,
			SwId = Helper.GetIdFromUrl(film.Url),
			CreatedAt = DateTime.Now.ToUniversalTime(),
			UpdatedAt = DateTime.Now.ToUniversalTime()
		};

		foreach (var character in film.Characters)
		{
			movie.CharactersSwIds.Add(Helper.GetIdFromUrl(character));
		}

		foreach (var planets in film.Planets)
		{
			movie.PlanetsSwIds.Add(Helper.GetIdFromUrl(planets));
		}

		foreach (var vehicles in film.Vehicles)
		{
			movie.VehiclesSwIds.Add(Helper.GetIdFromUrl(vehicles));
		}

		foreach (var starships in film.Starships)
		{
			movie.StarshipsSwIds.Add(Helper.GetIdFromUrl(starships));
		}

		DateTime.SpecifyKind(movie.CreatedAt, DateTimeKind.Utc);
		DateTime.SpecifyKind(movie.UpdatedAt, DateTimeKind.Utc);

		return movie;
	}
}
