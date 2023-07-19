using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Xml.Linq;
using VitrineUsadosAPI.Helpers;
using VitrineUsadosAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>();


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();

var app = builder.Build();

//Aplicar as migrations:
using (var scope = app.Services.CreateScope())
{
	var context = scope.ServiceProvider.GetRequiredService<DataContext>();

	context.Database.Migrate();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
