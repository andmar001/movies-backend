using PeliculasAPI.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeliculasAPI.Repositorio
{
    public interface IRepositorio
    {
        Task<Genero> ObtenerGeneroPorId(int id);
        List<Genero> ObtenerTodosLosGeneros();
    }
}
