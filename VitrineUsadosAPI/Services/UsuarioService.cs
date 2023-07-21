using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VitrineUsadosAPI.Helpers;
using VitrineUsadosAPI.Models;
using VitrineUsadosAPI.ViewModels;

namespace VitrineUsadosAPI.Services
{
	public class UsuarioService : IUsuarioService
	{
		private readonly DataContext _context;
		private readonly IConfiguration _configuration;
		private readonly byte[] _secret;
		private readonly JwtSecurityTokenHandler _tokenHandler;


		public UsuarioService
		(
			DataContext context,
			IConfiguration configuration
		)
		{
			_context = context;
			_configuration = configuration;

			_tokenHandler = new JwtSecurityTokenHandler();
			_secret = Encoding.ASCII.GetBytes(_configuration.GetSection("Secret").Value);
		}


		public async Task<LoginResponseViewModel> Login(string email, string senha)
		{
			var usuario = _context.Usuarios.SingleOrDefault(u => u.Email == email);

			if (usuario == null || !BCrypt.Net.BCrypt.EnhancedVerify(senha, usuario.Senha))
			{
				throw new ApplicationException("Usuario ou senha inválido.");
			}
			
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[] { new Claim("id", usuario.Id.ToString()) }),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_secret), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = _tokenHandler.WriteToken(_tokenHandler.CreateToken(tokenDescriptor));

			return new LoginResponseViewModel { Usuario = usuario, Token = token };
		}

		public async Task<Usuario?> ValidarToken(string token)
		{
			try
			{
				_tokenHandler.ValidateToken(token, new TokenValidationParameters 
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(_secret),
					ValidateIssuer = false,
					ValidateAudience = false,
					ClockSkew = TimeSpan.Zero
				}, out SecurityToken validatedToken);

				var jwtToken = (JwtSecurityToken)validatedToken;
				var id = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

				return await Obter(id);
			}
			catch
			{
				return null;
			}
		}

		public async Task<Usuario?> Obter(int id)
		{
			return await _context.Usuarios.FindAsync(id);
		}

		public async Task<IEnumerable<Usuario>> Todos()
		{
			return await _context.Usuarios.ToListAsync();
		}
	}
}
