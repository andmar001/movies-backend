﻿using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.Entidades
{
    public class Cine
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:75)]
        public string Nombre { get; set; }
        public Point Ubicacion { get; set; }
        //relaciones
        public List<PeliculasCines> PeliculasCines { get; set; }
    }
}
