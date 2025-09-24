using System.Xml.Linq;
using TestExercise.Models;
using TestExercise.Services.Iterfaces;

namespace TestExercise.Services
{
	 public class FileService : IFileService
	 {
		  // метод чтения фйала
		  public async Task<List<string>> ReadFileAsync(string filePath)
		  {
				var lines = new List<string>();

				using (var reader = new StreamReader(filePath))
				{
					 string? line;
					 while ((line = await reader.ReadLineAsync()) != null)
					 {
						  lines.Add(line);
					 }
				}

				return lines;
		  }

		  // метод парсинга
		  public Task<List<AdPlatform>> ParseLinesAsync(List<string> lines)
		  {
				var result = new List<AdPlatform>();

				foreach (var line in lines)
				{
					 if (string.IsNullOrWhiteSpace(line) || !line.Contains(":"))
						  continue;

					 var splitIntoNamesAndLocations = line.Split(':');
					 var name = splitIntoNamesAndLocations[0].Trim();
					 var locations = splitIntoNamesAndLocations[1]
						  .Trim()
						  .Split(',', StringSplitOptions.RemoveEmptyEntries)
						  .Select(l => l.Trim())
						  .ToList();

					 var platform = new AdPlatform
					 {
						  Name = name,
						  Locations = locations
					 };

					 result.Add(platform);
				}

				return Task.FromResult(result);
		  }

	 }
}