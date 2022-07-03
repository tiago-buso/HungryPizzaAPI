using HungryPizzaAPI.Models.Dominios;
using HungryPizzaAPI.Models.DTOs;

namespace HungryPizzaAPI.Services
{
    public interface IPizzaService : IBaseErroService
    {
        Task<List<Pizza>> MontarPizzas(List<PizzaDTO> pizzasDTOs);
    }
}