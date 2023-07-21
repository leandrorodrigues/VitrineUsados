using Microsoft.EntityFrameworkCore;
using VitrineUsadosAPI.Models;

namespace VitrineUsadosAPI.Helpers
{
	public class DataContext: DbContext
	{
		protected readonly IConfiguration Configuration;

		public DataContext(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			var connectionString = Configuration.GetConnectionString("VitrineUsadosDb");
			options.UseSqlite(connectionString);
		}

		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Carro> Carros { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Usuario>()
				.ToTable("Usuarios");

			modelBuilder.Entity<Carro>()
				.ToTable("Carros");			
		}
	}
}
