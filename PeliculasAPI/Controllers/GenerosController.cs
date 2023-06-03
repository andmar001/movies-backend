using Microsoft.AspNetCore.Mvc;
using PeliculasAPI.Repositorio;

namespace PeliculasAPI.Controllers
{
    public class GenerosController : Controller
    {
        private readonly IRepositorio _repositorio;

        public GenerosController(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
