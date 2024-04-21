using SwapiScraping.SwapiModels;

namespace SwapiScraping.Models;

public class Movie
{
	public int Id { get; set; }
	public string Title { get; set; } = string.Empty;
	public int Episode { get; set; }
	public string OpeningCrawl { get; set; } = string.Empty;
	public string Director { get; set; } = string.Empty;
	public string Producer { get; set; } = string.Empty;
	public DateTime ReleaseDate { get; set; }
	public IList<int> Characters { get; set; } = [];
	public IList<int> Planets { get; set; } = [];
	public IList<int> Vehicles { get; set; } = [];
	public IList<int> Starships { get; set; } = [];

	public static implicit operator Movie(SWFilm film)
	{
		var movie = new Movie()
		{
			Title = film.Title,
			Episode = film.EpisodeId,
			OpeningCrawl = film.OpeningCrawl,
			Director = film.Director,
			Producer = film.Producer,
			ReleaseDate = film.ReleaseDate,
			Id = Helper.GetIdFromUrl(film.Url)
		};

		foreach (var character in film.Characters)
		{
			movie.Characters.Add(Helper.GetIdFromUrl(character));
		}

		foreach (var planets in film.Planets)
		{
			movie.Planets.Add(Helper.GetIdFromUrl(planets));
		}

		foreach (var vehicles in film.Vehicles)
		{
			movie.Vehicles.Add(Helper.GetIdFromUrl(vehicles));
		}

		foreach (var starships in film.Starships)
		{
			movie.Starships.Add(Helper.GetIdFromUrl(starships));
		}

		return movie;
	}
}
