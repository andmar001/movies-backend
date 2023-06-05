using PeliculasAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeliculasAPI.Repositorio
{
    public interface IRepositorio
    {
        void CrearGenero(Genero genero);
        Task<Genero> ObtenerGeneroPorId(int id);
        Guid ObtenerGuid();
        List<Genero> ObtenerTodosLosGeneros();
    }
}
