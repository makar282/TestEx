using TestExercise.Services;
using TestExercise.Services.Iterfaces;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddSingleton<IPlatformService, PlatformService>();
builder.Services.AddEndpointsApiExplorer();


// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Swagger (работает и в Dev, и в Prod, если оставить)
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	 name: "default",
	 pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

