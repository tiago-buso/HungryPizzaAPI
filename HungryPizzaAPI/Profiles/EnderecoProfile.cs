using AutoMapper;
using HungryPizzaAPI.Models.Dominios;
using HungryPizzaAPI.Models.Persistencias;

namespace HungryPizzaAPI.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            // Source - Target

            CreateMap<Endereco, EnderecoPersistencia>();
        }
    }
}
