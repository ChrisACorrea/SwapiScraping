using System.Text.Json;
using System.Text.Json.Serialization;

namespace SwapiScraping;

public class SwapiService<T>
{
	private readonly HttpClient _client = new();

	public async Task<List<T>> GetData(string resourceUrl)
	{
		var data = new List<T>();
		var HasNext = true;
		do
		{
			var response = await GetPartialData(resourceUrl);
			data.AddRange(response.Results);

			if (response.Next is null or "null")
			{
				HasNext = false;
			}

			resourceUrl = response.Next!;

		} while (HasNext);

		return data;
	}

	private async Task<Response<T>> GetPartialData(string resourceUrl)
	{
		HttpResponseMessage response = await _client.GetAsync(resourceUrl);
		response.EnsureSuccessStatusCode();
		var responseBody = await response.Content.ReadAsStringAsync();

		var options = new JsonSerializerOptions
		{
			PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
			WriteIndented = true,
			MaxDepth = 64
		};

		return JsonSerializer.Deserialize<Response<T>>(responseBody, options);
	}
}

record Response<T>(int Count, string? Next, string? Previous, T[] Results);