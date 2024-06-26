﻿namespace SwapiScraping.SwapiModels;

public class SWPlanet
{
	public string Name { get; set; } = string.Empty;
	public string Diameter { get; set; } = string.Empty;
	public string RotationPeriod { get; set; } = string.Empty;
	public string OrbitalPeriod { get; set; } = string.Empty;
	public string Gravity { get; set; } = string.Empty;
	public string Population { get; set; } = string.Empty;
	public string Climate { get; set; } = string.Empty;
	public string Terrain { get; set; } = string.Empty;
	public string SurfaceWater { get; set; } = string.Empty;
	public IEnumerable<string> Residents { get; set; } = [];
	public IEnumerable<string> Films { get; set; } = [];
	public string Url { get; set; } = string.Empty;
	public string Created { get; set; } = string.Empty;
	public string Edited { get; set; } = string.Empty;
}
