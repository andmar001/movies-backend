using AutoMapper;
using NetTopologySuite.Geometries;
using PeliculasAPI.DTOs;
using PeliculasAPI.Entidades;

namespace PeliculasAPI.Utilidades
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles(GeometryFactory geometryFactory)
        {
            CreateMap<Genero, GeneroDTO>().ReverseMap();  //para get
            CreateMap<GeneroCreacionDTO, Genero>();  //para creacion
            CreateMap<Actor, ActorDTO>().ReverseMap();
            CreateMap<ActorCreacionDTO, Actor>()
                .ForMember(x => x.Foto, options => options.Ignore());  //Foto es ignorada en la creacion, porque se crea en otro metodo

            // mapeo de longitud y latitud hacia el tipo "Point"
            CreateMap<CineCreacionDTO, Cine>()
                .ForMember(x => x.Ubicacion, x => x.MapFrom(dto => 
                    geometryFactory.CreatePoint(new Coordinate(dto.Longitud, dto.Latitud))));
        }
    }
}
