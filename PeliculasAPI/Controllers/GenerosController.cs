using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using PeliculasAPI.Entidades;
using PeliculasAPI.Filtros;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace PeliculasAPI.Controllers
{
    [Route("api/generos")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]//proteccion 401 unauthorized a nivel de controller
    public class GenerosController : Controller
    {
        private readonly ILogger<GenerosController> _loguer;

        public GenerosController(
                    ILogger<GenerosController> loguer)
        {
            _loguer = loguer;
        }
        [HttpGet]
        [ServiceFilter(typeof(MiFiltroDeAccion))] // agregar filtros personalizados
        public ActionResult<List<Genero>> Generos()
        {
            return new List<Genero>() { new Genero() { Id=1, Nombre="Comedia"} };
        }
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Genero>> GetById(int Id)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public ActionResult Post([FromBody]Genero genero)
        {
            throw new NotImplementedException();
        }
        [HttpPut]
        public ActionResult Put()
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        public ActionResult Delete()
        {
            throw new NotImplementedException();
        }
    }
}
