using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VitrineUsadosAPI.Helpers;
using VitrineUsadosAPI.Models;
using VitrineUsadosAPI.Services;
using VitrineUsadosAPI.ViewModels;
using WebApi.Authorization;

namespace VitrineUsadosAPI.Controllers
{
    
    [Route("api/[controller]")]
    [Administrador]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;

		public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost("Login")]
        [Publico]
        public async Task<IActionResult> Login(LoginRequestViewmodel request)
        {
            LoginResponseViewModel response;
            try
            {
                response = await _service.Login(request.Email, request.Senha);
            }
            catch (Exception ex)
            {
                return new JsonResult(
				    new { message = "Não Autorizado" }
			    )
				{
					StatusCode = StatusCodes.Status401Unauthorized
				};
			}

            return Ok(response);
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> Todos()
        {
            var usuarios = await _service.Todos();

		    if ( usuarios == null)
            {
                return NotFound();
            }
            return usuarios.ToList();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> Obter(int id)
        {
            var usuario = await _service.Obter(id);
            if (usuario  == null)
            {
                return NotFound();
            }

            return usuario;
        }
    }
}
