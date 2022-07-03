using AutoMapper;
using Flunt.Notifications;
using HungryPizzaAPI.Models.Dominios;
using HungryPizzaAPI.Models.DTOs;

namespace HungryPizzaAPI.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly ISaboresService _saboresService;
        private readonly IMapper _mapper;

        public PizzaService(ISaboresService saboresService, IMapper mapper)
        {
            _saboresService = saboresService;
            _mapper = mapper;
        }

        public List<string> AdicionarErros()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Pizza>> MontarPizzas(List<PizzaDTO> pizzasDTOs)
        {
            List<Pizza> pizzas = new List<Pizza>();

            foreach (var pizzaDTO in pizzasDTOs)
            {
                List<Sabor> saboresPizza = await _saboresService.SelecionarSaboresPorIds(pizzaDTO.SaboresIds);

                if (saboresPizza != null)
                {
                    ValidarPizzas(pizzas, saboresPizza);
                }
            }

            return pizzas;
        }

        private void ValidarPizzas(List<Pizza> pizzas, List<Sabor> saboresPizza)
        {
            Pizza pizza = new Pizza(sabores: saboresPizza, pedidoId: null);

            if (pizza.IsValid)
            {
                pizzas.Add(pizza);
            }
            else
            {
                throw new Exception(String.Join(", ", pizza.Notifications.ToList().Select(x => x.Message).ToArray()));
            }
        }
    }
}
