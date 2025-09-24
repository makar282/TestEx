using TestExercise.Models;

namespace TestExercise.Services.Iterfaces
{
	 public interface IFileService
	 {
		  Task<List<AdPlatform>> ParseLinesAsync(List<string> lines);
		  Task<List<string>> ReadFileAsync(string filePath);
	 }
}