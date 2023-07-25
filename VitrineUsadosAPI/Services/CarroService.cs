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
			_context = context;
		}

		public async Task<Carro?> Obter(int id)
		{
			return await _context.Carros.FindAsync(id);
		}

		public async Task<IEnumerable<Carro>> Todos()
		{
			return await _context.Carros.ToListAsync();
		}

		public async Task Editar(Carro carro)
		{
			_context.Entry(carro).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
		public async Task Salvar(Carro carro)
		{
			_context.Carros.Add(carro);
			await _context.SaveChangesAsync();
		}

		public async Task Excluir(int id)
		{
			Carro carro = await Obter(id)
				?? throw new ArgumentOutOfRangeException(nameof(Carro));
			_context.Carros.Remove(carro);
			await _context.SaveChangesAsync();
		}



	}
}
