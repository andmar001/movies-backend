using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PeliculasAPI.DTOs;
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
        private readonly IMapper mapper;

        public GenerosController(
                    ILogger<GenerosController> loguer,
                    ApplicationDbContext context,
                    IMapper mapper)
        {
            this.loguer = loguer;
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        [ServiceFilter(typeof(MiFiltroDeAccion))] // agregar filtros personalizados
        public async Task<ActionResult<List<GeneroDTO>>> Get()
        {
            var generos = await context.Generos.ToListAsync();
            return mapper.Map<List<GeneroDTO>>(generos);
        }
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Genero>> GetById(int Id)
        {
            return StatusCode(400);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]GeneroCreacionDTO generoCreacionDTO)
        {
            var genero = mapper.Map<Genero>(generoCreacionDTO);
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
