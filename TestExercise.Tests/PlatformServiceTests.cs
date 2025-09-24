using System.Collections.Generic;
using System.Runtime.InteropServices;
using TestExercise.Models;
using TestExercise.Services;
using Xunit;

namespace TestExercise.Tests
{
	 public class PlatformServiceTests
	 {
		  [Fact]
		  public void GetPlatformsForLocation_RootLocation_ReturnsOnlyGlobal()
		  {
				// Arrange
				var service = new PlatformService();
				service.StorePlatforms(new List<AdPlatform>
				{
					 new AdPlatform { Name = "Яндекс.Директ", Locations = new List<string>{ "/ru" } },
					 new AdPlatform { Name = "Крутая реклама", Locations = new List<string>{ "/ru/svrd" } }
				});

				// Act
				var result = service.GetPlatformsForLocation("/ru");

				// Assert
				Assert.Contains("Яндекс.Директ", result);
				Assert.DoesNotContain("Крутая реклама", result);
		  }

		  [Fact]
		  public void GetPlatformsForLocation_SubLocation_ReturnsParentAndChild()
		  {
				// Arrange
				var service = new PlatformService();
				service.StorePlatforms(new List<AdPlatform>
				{
					 new AdPlatform { Name = "Яндекс.Директ", Locations = new List<string>{ "/ru" } },
					 new AdPlatform { Name = "Крутая реклама", Locations = new List<string>{ "/ru/svrd" } },
					 new AdPlatform { Name = "Ревдинский рабочий", Locations = new List<string>{ "/ru/svrd/revda" } }
				});

				// Act
				var result = service.GetPlatformsForLocation("/ru/svrd/revda");

				// Assert
				Assert.Contains("Яндекс.Директ", result);
				Assert.Contains("Крутая реклама", result);
				Assert.Contains("Ревдинский рабочий", result);
		  }

		  [Fact]
		  public void GetPlatformsForLocation_UnknownLocation_ReturnsEmpty()
		  {
				// Arrange
				var service = new PlatformService();
				service.StorePlatforms(new List<AdPlatform>
				{
					 new AdPlatform { Name = "Яндекс.Директ", Locations = new List<string>{ "/ru" } }
				});

				// Act
				var result = service.GetPlatformsForLocation("/us");

				// Assert
				Assert.Empty(result);
		  }
	 }
}
