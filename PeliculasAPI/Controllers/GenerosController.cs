﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;
using PeliculasAPI.Filtros;
using PeliculasAPI.Utilidades;
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
    public class GenerosController : ControllerBase
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
        public async Task<ActionResult<List<GeneroDTO>>> Get([FromQuery]PaginacionDTO paginacionDTO)
        {
            var queryable = context.Generos.AsQueryable();
            //contar la cantidad de generos en la BD, pasandole el contexto de "Generos" para que de ahí cuente
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);
            //buscar generos por nombre
            var generos = await queryable.OrderBy(x => x.Nombre).Paginar(paginacionDTO).ToListAsync();
            return mapper.Map<List<GeneroDTO>>(generos);
        }
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<GeneroDTO>> GetById(int Id)
        {
            var genero = await context.Generos.FirstOrDefaultAsync(x => x.Id == Id);
            if (genero == null)
            {
                return NotFound();
            }

            return mapper.Map<GeneroDTO>(genero);

        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]GeneroCreacionDTO generoCreacionDTO)
        {
            var genero = mapper.Map<Genero>(generoCreacionDTO);
            context.Add(genero);
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int Id, [FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            var genero = await context.Generos.FirstOrDefaultAsync(x => x.Id == Id);
            if (genero == null)
            {
                return NotFound();
            }

            genero = mapper.Map(generoCreacionDTO, genero);
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var existe = await context.Generos.AnyAsync(x => x.Id == Id);

            if (!existe)
            {
                return NotFound();
            }
            
            context.Remove(new Genero() { Id = Id });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
