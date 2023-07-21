using VitrineUsadosAPI.Models;

namespace VitrineUsadosAPI.Services
{
	public interface ICarroService
	{
		Task<Carro?> Obter(int id);
		Task<IEnumerable<Carro>> Todos();
	}
}