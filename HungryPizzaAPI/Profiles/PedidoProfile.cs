using AutoMapper;
using HungryPizzaAPI.Models.DTOs;
using HungryPizzaAPI.Models.Persistencias;

namespace HungryPizzaAPI.Profiles
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            // Source - Targert

            CreateMap<PedidoPersistencia, PedidoDTO>();
         
            //CreateMap<Platform, GrpcPlatformModel>()
            //    .ForMember(dest => dest.PlatformId, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            //    .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.Publisher));
        }
    }
}
