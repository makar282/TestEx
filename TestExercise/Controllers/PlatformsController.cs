using Microsoft.AspNetCore.Mvc;
using TestExercise.Services.Iterfaces;

namespace TestExercise.Controllers
{
	 [ApiController]
	 [Route("api/[controller]")]
	 public class PlatformsController(IFileService _fileService, IPlatformService _platformService, IWebHostEnvironment _env) : ControllerBase
	 {
		  /// <summary>
		  /// загрузка платформ-локаций
		  /// </summary>
		  /// <returns></returns>
		  [HttpPost("upload")]
		  public async Task<IActionResult> Upload()
		  {
				var _filePath = Path.Combine(_env.ContentRootPath, "wwwroot//file.txt");

				var lines = await _fileService.ReadFileAsync(_filePath);
				var platforms = await _fileService.ParseLinesAsync(lines);
				_platformService.StorePlatforms(platforms);

				return Ok();
		  }

		  /// <summary>
		  /// возврат по запросу платформ
		  /// </summary>
		  /// <param name="location"></param>
		  /// <returns></returns>
		  [HttpGet("platforms/{*location}")]
		  public IActionResult GetPlatforms(string location)
		  {
				var raw = location ?? string.Empty;
				raw = Uri.UnescapeDataString(raw).Trim();

				if (!raw.StartsWith("/")) raw = "/" + raw;
				while (raw.Contains("//")) raw = raw.Replace("//", "/");
				raw = raw.TrimEnd('/');

				var platforms = _platformService.GetPlatformsForLocation(raw);

				return Ok(new { requested = raw, platforms = platforms });
		  }
	 }
}
