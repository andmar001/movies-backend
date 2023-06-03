using Microsoft.AspNetCore.Mvc;
using PeliculasAPI.Entidades;
using PeliculasAPI.Repositorio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeliculasAPI.Controllers
{
    [Route("api/generos")]
    public class GenerosController : Controller
    {
        private readonly IRepositorio _repositorio;

        public GenerosController(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        [HttpGet]
        public ActionResult<List<Genero>> GetById()
        {
            return _repositorio.ObtenerTodosLosGeneros();
        }
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Genero>> Get(int Id)
        {
            var genero = await _repositorio.ObtenerGeneroPorId(Id);

            if (genero == null)
            {
                return NotFound();
            }

            return genero;
        }

        [HttpPost]
        public ActionResult Post()
        {
            return NoContent();
        }
        [HttpPut]
        public ActionResult Put()
        {
            return NoContent();
        }
        [HttpDelete]
        public ActionResult Delete()
        {
            return NoContent();
        }
        [HttpPost("qw")]
        public IActionResult Post(int id)
        {
            var genre = _repositorio.ObtenerGeneroPorId(id);

            if (genre == null)
            {
                return NotFound(id);
            }

            return Ok(genre);
        }
    }
}
