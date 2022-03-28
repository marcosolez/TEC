using AutoMapper;
using FinFast.DATOS.DTOs;
using FinFast.DATOS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinFast.API.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Persona, PersonasListDTO>();
            CreateMap<Persona, PersonaDetalleDTO>();
            CreateMap<PersonaPostDTO, Persona>();

            CreateMap<Ciudad, CiudadDTO>()
                .ForMember(dest => dest.ID,
                 opt => opt.MapFrom(src => src.Codigo));

            CreateMap<Region, RegionDTO>()
                 .ForMember(dest => dest.ID,
                 opt => opt.MapFrom(src => src.Codigo));

            CreateMap<Comuna, ComunaDTO>()
                .ForMember(dest=>dest.ID,
                 opt=>opt.MapFrom(src=>src.Codigo))
                 .ForMember(dest => dest.IDCIUDAD,
                 opt => opt.MapFrom(src => src.CiudadCodigo))
                  .ForMember(dest => dest.IDREGION,
                 opt => opt.MapFrom(src => src.RegionCodigo));

            CreateMap<Sexo, SexoDTO>()
                 .ForMember(dest => dest.ID,
                 opt => opt.MapFrom(src => src.Codigo));

        }
    }
  
}
