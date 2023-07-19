using VitrineUsadosAPI.Models;
using VitrineUsadosAPI.ViewModels;

namespace VitrineUsadosAPI.Services
{
	public interface IUsuarioService
	{
		Task<LoginResponseViewModel> Login(string email, string senha);
		Task<Usuario?> Obter(int id);
		Task<IEnumerable<Usuario>> Todos();
		Task<Usuario?> ValidarToken(string token);
	}
}