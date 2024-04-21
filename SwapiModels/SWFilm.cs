namespace SwapiScraping.SwapiModels;

public class SWFilm
{
	public string Title { get; set; } = string.Empty;
	public int EpisodeId { get; set; }
	public string OpeningCrawl { get; set; } = string.Empty;
	public string Director { get; set; } = string.Empty;
	public string Producer { get; set; } = string.Empty;
	public DateTime ReleaseDate { get; set; }
	public IEnumerable<string> Species { get; set; } = [];
	public IEnumerable<string> Starships { get; set; } = [];
	public IEnumerable<string> Vehicles { get; set; } = [];
	public IEnumerable<string> Characters { get; set; } = [];
	public IEnumerable<string> Planets { get; set; } = [];
	public string Url { get; set; } = string.Empty;
	public string Created { get; set; } = string.Empty;
	public string Edited { get; set; } = string.Empty;
}
