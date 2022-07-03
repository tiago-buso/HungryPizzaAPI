using HungryPizzaAPI.Data;
using HungryPizzaAPI.Models.Dominios;
using HungryPizzaAPI.Models.DTOs;
using HungryPizzaAPI.Models.Persistencias;
using HungryPizzaAPI.Repositories;
using HungryPizzaAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HungryPizzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;      
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IPedidoService _pedidoService;
        private readonly IPizzaService _pizzaService;

        public PedidoController(IClienteRepository clienteRepository, IEnderecoRepository enderecoRepository, IPedidoService pedidoService, IPizzaService pizzaService)
        {
            _clienteRepository = clienteRepository;
            _enderecoRepository = enderecoRepository;
            _pedidoService = pedidoService;
            _pizzaService = pizzaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidoDTO>>> SelecionarPedidosPaginadosPorClienteOrdenadosDataDesc(int clienteId, int skip, int take)
        {
            if (skip < 0)
            {
                return BadRequest("Parâmetro skip não passado corretamente, por favor, passar um valor maior ou igual a zero");
            }

            if (take <= 0)
            {
                return BadRequest("Parâmetro take não passado corretamente, por favor, passar um valor maior que zero");
            }

            bool clienteExiste = await _clienteRepository.ClienteExiste(clienteId);

            if (!clienteExiste)
            {
                return BadRequest("Não foi encontrado um cliente com esse clienteId.");
            }

            List<PedidoDTO> pedidos = await _pedidoService.SelecionarPedidosPaginadosPorClienteOrdenadosDataDesc(clienteId: clienteId, skip: skip, take: take);

            return Ok(pedidos);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CriarPedido(List<PizzaDTO> pizzasDTOs, int? clienteId, int? enderecoId)
        {
            if (!clienteId.HasValue && !enderecoId.HasValue)
            {
                return BadRequest("Não foi passado nem clienteId, nem enderecoId, por favor passe um dos dois parâmetros.");
            }

            if (clienteId.HasValue)
            {
                bool clienteExiste = await _clienteRepository.ClienteExiste(clienteId.Value);

                if (!clienteExiste)
                {
                    return BadRequest("Não foi encontrado um cliente com esse clienteId.");
                }
            }

            if (enderecoId.HasValue)
            {
                bool enderecoExiste = await _enderecoRepository.EnderecoExiste(enderecoId.Value);

                if (!enderecoExiste)
                {
                    return BadRequest("Não foi encontrado um endereço com esse enderecoId.");
                }
            }

            if (clienteId.HasValue && enderecoId.HasValue)
            {
                return BadRequest("Não é possível criar esse pedido, passe ou um cliente ou um endereço, não passe os dois.");
            }

            List<Pizza> pizzas = new List<Pizza>();

            try
            {
                pizzas = await _pizzaService.MontarPizzas(pizzasDTOs);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao montar as pizzas: {ex.Message}");
            }

            int pedidoId = 0;

            try
            {
                pedidoId = await _pedidoService.CriarPedido(data: DateTime.Now, pizzas: pizzas, enderecoId: enderecoId, clienteId: clienteId);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar o pedido: {ex.Message}");
            }

            return Ok(pedidoId);
            
        }
    }
}
