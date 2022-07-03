using AutoMapper;
using HungryPizzaAPI.Models.Dominios;
using HungryPizzaAPI.Models.Persistencias;

namespace HungryPizzaAPI.Profiles
{
    public class PizzaProfile : Profile
    {
        public PizzaProfile()
        {
            // Source - Target
          
            CreateMap<Pizza, PizzaPersistencia>();
        }
    }
}
