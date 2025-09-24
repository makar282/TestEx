using TestExercise.Models;

namespace TestExercise.Services.Iterfaces
{
	 public interface IPlatformService
	 {
		  public void StorePlatforms(List<AdPlatform> platformsList);
		  List<string> GetPlatformsForLocation(string location);
	 }
}
