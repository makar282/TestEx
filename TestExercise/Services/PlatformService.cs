using TestExercise.Models;
using TestExercise.Services.Iterfaces;

namespace TestExercise.Services
{
	 public class PlatformService : IPlatformService
	 {
		  private Dictionary<string, List<string>> _locations = new();

		  // храним данные в озу
		  public void StorePlatforms(List<AdPlatform> platformsList)
		  {
				_locations.Clear();

				foreach (var platform in platformsList)
				{
					 foreach (var location in platform.Locations)
					 {
						  if (!_locations.ContainsKey(location))
								_locations[location] = new List<string>();

						  _locations[location].Add(platform.Name);
					 }
				}
		  }

		  // получаем платформы по локации
		  public List<string> GetPlatformsForLocation(string location)
		  {
				var result = new List<string>();

				var segments = location.Trim('/').Split('/');
				var prefix = "";

				foreach (var segment in segments)
				{
					 prefix += "/" + segment;

					 if (_locations.TryGetValue(prefix, out var platforms))
					 {
						  result.AddRange(platforms);
					 }
				}

				return result.Distinct().ToList();
		  }
	 }
}
