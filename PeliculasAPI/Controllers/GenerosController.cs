using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PeliculasAPI.Entidades;
using PeliculasAPI.Repositorio;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace PeliculasAPI.Controllers
{
    [Route("api/generos")]
    [ApiController]
    public class GenerosController : Controller
    {
        private readonly IRepositorio _repositorio;
        private readonly WeatherForecastController _weatherForecastController;

        public GenerosController(IRepositorio repositorio, WeatherForecastController weatherForecastController)
        {
            _repositorio = repositorio;
            _weatherForecastController = weatherForecastController;
        }
        [HttpGet("generos")]
        public ActionResult<List<Genero>> Generos()
        {
            return _repositorio.ObtenerTodosLosGeneros();
        }
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Genero>> GetById(int Id, [FromBody] string nombre)
        {
            var genero = await _repositorio.ObtenerGeneroPorId(Id);

            if (genero == null)
            {
                return NotFound();
            }
            return genero;
        }
        [HttpGet("guid")]
        public ActionResult<Guid> GetGuid()
        {
            return Ok(new
            {
                Guid_GenerosController = _repositorio.ObtenerGuid(),
                Guid_WeatherController = _weatherForecastController.ObtenerGuidWeatherForecast()
            });
        }
        [HttpPost]
        public ActionResult Post([FromBody]Genero genero)
        {
            _repositorio.CrearGenero(genero);
            return Ok();
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
