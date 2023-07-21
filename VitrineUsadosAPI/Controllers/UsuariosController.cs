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
/*
        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
          if (_context.Usuarios == null)
          {
              return Problem("Entity set 'DataContext.Usuarios'  is null.");
          }
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            if (_context.Usuarios == null)
            {
                return NotFound();
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return (_context.Usuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
*/
    }
}
