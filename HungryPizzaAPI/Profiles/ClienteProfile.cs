using AutoMapper;
using HungryPizzaAPI.Models.Dominios;
using HungryPizzaAPI.Models.Persistencias;

namespace HungryPizzaAPI.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            // Source - Target

            CreateMap<Cliente, ClientePersistencia>();
        }
    }
}
