using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PeliculasAPI.Entidades;
using PeliculasAPI.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace PeliculasAPI.Controllers
{
    [Route("api/generos")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]//proteccion 401 unauthorized a nivel de controller
    public class GenerosController : Controller
    {
        private readonly ILogger<GenerosController> loguer;
        private readonly ApplicationDbContext context;

        public GenerosController(
                    ILogger<GenerosController> loguer,
                    ApplicationDbContext context)
        {
            this.loguer = loguer;
            this.context = context;
        }
        [HttpGet]
        [ServiceFilter(typeof(MiFiltroDeAccion))] // agregar filtros personalizados
        public async Task<ActionResult<List<Genero>>> Get()
        {
            return await context.Generos.ToListAsync();
        }
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Genero>> GetById(int Id)
        {
            return StatusCode(400);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Genero genero)
        {
            context.Add(genero);
            await context.SaveChangesAsync();
            return NoContent();
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
