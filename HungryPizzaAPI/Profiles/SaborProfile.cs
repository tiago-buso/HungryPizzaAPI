using AutoMapper;
using HungryPizzaAPI.Models.Dominios;
using HungryPizzaAPI.Models.Persistencias;

namespace HungryPizzaAPI.Profiles
{
    public class SaborProfile : Profile
    {
        public SaborProfile()
        {
            // Source - Target
            CreateMap<SaborPersistencia, Sabor>();
            CreateMap<Sabor, SaborPersistencia> ();
        }
    }
}
