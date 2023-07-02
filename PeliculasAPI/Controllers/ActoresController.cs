using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;
using PeliculasAPI.Utilidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeliculasAPI.Controllers
{
    [Route("api/actores")]
    [ApiController]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly string contenedor = "actores";

        public ActoresController(
                    ApplicationDbContext context,
                    IMapper mapper,
                    IAlmacenadorArchivos almacenadorArchivos)
        {
            this.context = context;
            this.mapper = mapper;
            this.almacenadorArchivos = almacenadorArchivos;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ActorCreacionDTO actorCreacionDTO)
        {
            var actor = mapper.Map<Actor>(actorCreacionDTO);
         
            //si cliente mando la foto - la guardamos en Azure
            if (actorCreacionDTO.Foto != null)
            {
                actor.Foto = await almacenadorArchivos.GuardarArchivo(contenedor, actorCreacionDTO.Foto);
            }
            
            context.Add(actor);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            var queryable = context.Actores.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);
            var actores = await queryable.Paginar(paginacionDTO).ToListAsync();
            return mapper.Map<List<ActorDTO>>(actores);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var existe = await context.Actores.AnyAsync(x => x.Id == Id);

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
