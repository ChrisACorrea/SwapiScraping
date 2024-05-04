namespace SwapiScraping.Models;

public abstract class Model
{
	public Guid Id { get; set; }
	public int SwId { get; set; }
	public DateTime CreatedAt { get; set; } = DateTime.Now.ToUniversalTime();
	public DateTime UpdatedAt { get; set; } = DateTime.Now.ToUniversalTime();
}
