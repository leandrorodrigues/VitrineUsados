using Microsoft.EntityFrameworkCore;
using VitrineUsadosAPI.Helpers;
using VitrineUsadosAPI.Models;

namespace VitrineUsadosAPI.Services
{
	public class CarroService : ICarroService
	{

		private readonly DataContext _context;

		public CarroService
		(
			DataContext context
		)
		{
			this._context = context;
		}

		public async Task<Carro?> Obter(int id)
		{
			return await _context.Carros.FindAsync(id);
		}

		public async Task<IEnumerable<Carro>> Todos()
		{
			return await _context.Carros.ToListAsync();
		}


	}
}
