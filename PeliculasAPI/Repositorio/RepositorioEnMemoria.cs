using PeliculasAPI.Entidades;
using System.Collections.Generic;

namespace PeliculasAPI.Repositorio
{
    public class RepositorioEnMemoria: IRepositorio
    {
        private List<Genero> _generos;

        public RepositorioEnMemoria()
        {
            _generos = new List<Genero>()
            {
                new Genero() { Id=1, Nombre="Comedia"},
                new Genero() { Id=2, Nombre="Acción"},
                new Genero() { Id=3, Nombre="Terror"}
            };
        }

        public List<Genero> ObtenerTodosLosGeneros()
        {
            return _generos;
        }

    }
}
