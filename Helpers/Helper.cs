namespace SwapiScraping;

public static class Helper
{
	public static int GetIdFromUrl(string url)
	{
		if (url.EndsWith("/"))
		{
			url = url.Remove(url.Length - 1);
		}

		// Encontrar a última barra na URL
		int lastIndex = url.LastIndexOf('/');

		// Extrair o ID
		string id = url.Substring(lastIndex + 1);
		return int.Parse(id);
	}
}
