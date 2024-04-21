using SwapiScraping.SwapiModels;

namespace SwapiScraping.Models;

public class Vehicle
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
	public string Consumables { get; set; } = string.Empty;
	public string Class { get; set; } = string.Empty;
	public IList<int> Movies { get; set; } = [];

	public static implicit operator Vehicle(SWVehicle swVehicle)
	{
		var vehicle = new Vehicle()
		{
			Name = swVehicle.Name,
			Model = swVehicle.Model,
			Manufacturer = swVehicle.Manufacturer,
			CostInCredits = swVehicle.CostInCredits,
			Length = swVehicle.Length,
			MaxSpeed = swVehicle.MaxAtmospheringSpeed,
			Crew = swVehicle.Crew,
			Passengers = swVehicle.Passengers,
			CargoCapacity = swVehicle.CargoCapacity,
			Consumables = swVehicle.Consumables,
			Class = swVehicle.VehicleClass,
			Id = Helper.GetIdFromUrl(swVehicle.Url)
		};

		foreach (var film in swVehicle.Films)
		{
			vehicle.Movies.Add(Helper.GetIdFromUrl(film));
		}

		return vehicle;
	}
}
