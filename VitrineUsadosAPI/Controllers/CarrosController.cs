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
using WebApi.Authorization;

namespace VitrineUsadosAPI.Controllers
{
    [Route("api/[controller]")]
    [Administrador]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        private readonly ICarroService _service;


		public CarrosController(ICarroService service)
        {
            _service = service;
        }

        // GET: api/Carros
        [HttpGet]
        [Publico]
        public async Task<ActionResult<IEnumerable<Carro>>> GetCarros()
        {
            var carros = await _service.Todos();

            if (carros == null)
            {
                return NotFound();
            }
            return Ok(carros);
        }

        // GET: api/Carros/5
        [HttpGet("{id}")]
        [Publico]
        public async Task<ActionResult<Carro>> GetCarro(int id)
        {
            var carro = await _service.Obter(id);

            if (carro == null)
            {
                return NotFound();
            }
           
            return Ok(carro);
        }
        
        // PUT: api/Carros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarro(int id, Carro carro)
        {
            if (id != carro.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.Editar(carro);
            }
            catch
            {
                return NotFound(); 
            }

            return NoContent();
        }

        // POST: api/Carros
        [HttpPost]
        public async Task<ActionResult<Carro>> PostCarro(Carro carro)
        {
          await _service.Salvar(carro);
          return CreatedAtAction("GetCarro", new { id = carro.Id }, carro);
        }

        // DELETE: api/Carros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarro(int id)
        {
            try
            {
                await _service.Excluir(id);
            }
            catch
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
