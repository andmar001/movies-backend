﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;
using PeliculasAPI.Utilidades;
using System.Threading.Tasks;

namespace PeliculasAPI.Controllers
{
    [Route("api/actores")]
    [ApiController]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorAzureStorage almacenadorAzure;
        private readonly string contenedor = "actores";

        public ActoresController(
                    ApplicationDbContext context,
                    IMapper mapper,
                    IAlmacenadorAzureStorage almacenadorAzure)
        {
            this.context = context;
            this.mapper = mapper;
            this.almacenadorAzure = almacenadorAzure;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ActorCreacionDTO actorCreacionDTO)
        {
            var actor = mapper.Map<Actor>(actorCreacionDTO);
         
            //si cliente mando la foto - la guardamos en Azure
            if (actorCreacionDTO.Foto != null)
            {
                actor.Foto = await almacenadorAzure.GuardarArchivo(contenedor, actorCreacionDTO.Foto);
            }
            
            context.Add(actor);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}