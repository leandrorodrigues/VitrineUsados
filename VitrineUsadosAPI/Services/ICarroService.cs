using VitrineUsadosAPI.Models;

namespace VitrineUsadosAPI.Services
{
	public interface ICarroService
	{
		Task Editar(Carro carro);
		Task Excluir(int id);
		Task<Carro?> Obter(int id);
		Task Salvar(Carro carro);
		Task<IEnumerable<Carro>> Todos();
	}
}