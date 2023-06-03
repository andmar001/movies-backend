using PeliculasAPI.Entidades;
using System.Collections.Generic;

namespace PeliculasAPI.Repositorio
{
    public interface IRepositorio
    {
        List<Genero> ObtenerTodosLosGeneros();
    }
}
