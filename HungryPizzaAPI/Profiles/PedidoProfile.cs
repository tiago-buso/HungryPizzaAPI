using AutoMapper;
using HungryPizzaAPI.Models.Dominios;
using HungryPizzaAPI.Models.DTOs;
using HungryPizzaAPI.Models.Persistencias;

namespace HungryPizzaAPI.Profiles
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            // Source - Target

            CreateMap<PedidoPersistencia, PedidoDTO>();
            CreateMap<Pedido, PedidoPersistencia>();                   
        }
    }
}
