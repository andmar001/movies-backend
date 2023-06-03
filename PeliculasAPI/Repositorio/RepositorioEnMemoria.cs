using PeliculasAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<Genero> ObtenerGeneroPorId(int id)
        {
            await Task.Delay(1); //3 seconds to simulate conection con database
            return _generos.FirstOrDefault(o => o.Id == id);
        }



    }
}
