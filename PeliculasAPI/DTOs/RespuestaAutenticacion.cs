﻿using System;

namespace PeliculasAPI.DTOs
{
    public class RespuestaAutenticacion
    {
        public string Token { get; set; }
        public  DateTime Expiracion { get; set; }
    }
}
