using PeliculasAPI.Entidades;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeliculasAPI.Utilidades;

namespace PeliculasAPI.DTOs
{
    public class PeliculaCreacionDTO
    {
        [Required]
        [StringLength(maximumLength: 300)]
        public string Titulo { get; set; }
        public string Resumen { get; set; }
        public string Trailer { get; set; }
        public string EnCines { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public IFormFile Poster { get; set; }
        [ModelBinder(binderType:typeof(TypeBinder<List<int>>))] // para que el model binder sepa que es una lista de enteros
        public List<int> GenerosIds { get; set; }
        [ModelBinder(binderType: typeof(TypeBinder<List<int>>))] // para que el model binder sepa que es una lista de enteros
        public List<int> CinesIds { get; set; }
        [ModelBinder(binderType: typeof(TypeBinder<List<ActorPeliculaCreacionDTO>>))] // para que el model binder sepa que es una lista de ActorPeliculaCreacionDTO
        public List<ActorPeliculaCreacionDTO> Actores { get; set; }
    }
}
