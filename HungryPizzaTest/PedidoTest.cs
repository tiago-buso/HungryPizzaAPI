using FluentAssertions;
using HungryPizzaAPI.Models.Dominios;
using HungryPizzaAPI.Models.DTOs;
using HungryPizzaAPI.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizzaTest
{
    public class PedidoTest
    {
        private List<Pizza> SelecionarPizzasPorQuantidade(int quantidade)
        {
            List<Pizza> pizzas = new List<Pizza>();
            List<Sabor> sabores = new List<Sabor>();

            sabores.Add(new Sabor(descricao: "3 Queijos", preco: 50M, emFalta: false));
            sabores.Add(new Sabor(descricao: "Frango com requeijão", preco: 59.99M, emFalta: false));

            pizzas.Add(new Pizza(sabores.Skip(0).Take(1).ToList(), null));
            pizzas.Add(new Pizza(sabores.Skip(0).Take(2).ToList(), null));
            pizzas.Add(new Pizza(sabores.Skip(0).Take(1).ToList(), null));
            pizzas.Add(new Pizza(sabores.Skip(0).Take(2).ToList(), null));
            pizzas.Add(new Pizza(sabores.Skip(0).Take(1).ToList(), null));
            pizzas.Add(new Pizza(sabores.Skip(0).Take(2).ToList(), null));
            pizzas.Add(new Pizza(sabores.Skip(0).Take(1).ToList(), null));
            pizzas.Add(new Pizza(sabores.Skip(0).Take(2).ToList(), null));
            pizzas.Add(new Pizza(sabores.Skip(0).Take(1).ToList(), null));
            pizzas.Add(new Pizza(sabores.Skip(0).Take(2).ToList(), null));

            pizzas.Add(new Pizza(sabores.Skip(0).Take(1).ToList(), null));
            pizzas.Add(new Pizza(sabores.Skip(0).Take(2).ToList(), null));
            pizzas.Add(new Pizza(sabores.Skip(0).Take(1).ToList(), null));
            pizzas.Add(new Pizza(sabores.Skip(0).Take(2).ToList(), null));
            pizzas.Add(new Pizza(sabores.Skip(0).Take(1).ToList(), null));
            pizzas.Add(new Pizza(sabores.Skip(0).Take(2).ToList(), null));
            pizzas.Add(new Pizza(sabores.Skip(0).Take(1).ToList(), null));
            pizzas.Add(new Pizza(sabores.Skip(0).Take(2).ToList(), null));


            return pizzas.Skip(0).Take(quantidade).ToList();
        }

        [Fact(DisplayName = "Instanciar corretamente um pedido - 1 pizza")]
        [Trait("Pedido", "Testes de criação de entidade de domínio de Pedido")]
        public async Task InstanciarPedidoCorretamente_UmaPizza()
        {
            // Arrange
            List<PizzaDTO> pizzasDTOs = new List<PizzaDTO>();

            Moq.Mock<IPizzaService> mockPizzasService = new Moq.Mock<IPizzaService>();
            mockPizzasService.Setup(x => x.MontarPizzas(pizzasDTOs)).ReturnsAsync(SelecionarPizzasPorQuantidade(1));

            List<Pizza> pizzas = await mockPizzasService.Object.MontarPizzas(pizzasDTOs);

            //Act
            Pedido pedido = new Pedido(data: DateTime.Now, pizzas: pizzas, enderecoId: null, clienteId: 1);

            // Assert
            pedido.IsValid.Should().BeTrue();
            pedido.Notifications.Should().HaveCount(0);
            pedido.Pizzas.Count().Should().Be(1);
        }

        [Fact(DisplayName = "Instanciar corretamente um pedido - 10 pizzas")]
        [Trait("Pedido", "Testes de criação de entidade de domínio de Pedido")]
        public async Task InstanciarPedidoCorretamente_DezPizzas()
        {
            // Arrange
            List<PizzaDTO> pizzasDTOs = new List<PizzaDTO>();

            Moq.Mock<IPizzaService> mockPizzasService = new Moq.Mock<IPizzaService>();
            mockPizzasService.Setup(x => x.MontarPizzas(pizzasDTOs)).ReturnsAsync(SelecionarPizzasPorQuantidade(10));

            List<Pizza> pizzas = await mockPizzasService.Object.MontarPizzas(pizzasDTOs);

            //Act
            Pedido pedido = new Pedido(data: DateTime.Now, pizzas: pizzas, enderecoId: null, clienteId: 1);

            // Assert
            pedido.IsValid.Should().BeTrue();
            pedido.Notifications.Should().HaveCount(0);
            pedido.Pizzas.Count().Should().Be(10);
        }

        [Fact(DisplayName = "Instanciar corretamente um pedido - 1 pizza - calcular valor total")]
        [Trait("Pedido", "Testes de criação de entidade de domínio de Pedido")]
        public async Task InstanciarPedidoCorretamente_UmaPizza_CalcularValorTotal()
        {
            // Arrange
            List<PizzaDTO> pizzasDTOs = new List<PizzaDTO>();

            Moq.Mock<IPizzaService> mockPizzasService = new Moq.Mock<IPizzaService>();
            mockPizzasService.Setup(x => x.MontarPizzas(pizzasDTOs)).ReturnsAsync(SelecionarPizzasPorQuantidade(1));

            List<Pizza> pizzas = await mockPizzasService.Object.MontarPizzas(pizzasDTOs);

            //Act
            Pedido pedido = new Pedido(data: DateTime.Now, pizzas: pizzas, enderecoId: null, clienteId: 1);

            // Assert
            pedido.IsValid.Should().BeTrue();
            pedido.Notifications.Should().HaveCount(0);
            pedido.Pizzas.Count().Should().Be(1);
            pedido.ValorTotal.Should().Be(50M);
        }

        [Fact(DisplayName = "Instanciar corretamente um pedido - 2 pizza - calcular valor total")]
        [Trait("Pedido", "Testes de criação de entidade de domínio de Pedido")]
        public async Task InstanciarPedidoCorretamente_DuasPizzas_CalcularValorTotal()
        {
            // Arrange
            List<PizzaDTO> pizzasDTOs = new List<PizzaDTO>();

            Moq.Mock<IPizzaService> mockPizzasService = new Moq.Mock<IPizzaService>();
            mockPizzasService.Setup(x => x.MontarPizzas(pizzasDTOs)).ReturnsAsync(SelecionarPizzasPorQuantidade(2));

            List<Pizza> pizzas = await mockPizzasService.Object.MontarPizzas(pizzasDTOs);

            //Act
            Pedido pedido = new Pedido(data: DateTime.Now, pizzas: pizzas, enderecoId: null, clienteId: 1);

            // Assert
            pedido.IsValid.Should().BeTrue();
            pedido.Notifications.Should().HaveCount(0);
            pedido.Pizzas.Count().Should().Be(2);
            pedido.ValorTotal.Should().Be(104.995M);
        }

        [Fact(DisplayName = "Instanciar incorretamente um pedido - data inválida")]
        [Trait("Pedido", "Testes de criação de entidade de domínio de Pedido")]
        public async Task InstanciarPedidoIncorretamente_DataInvalida()
        {
            // Arrange
            List<PizzaDTO> pizzasDTOs = new List<PizzaDTO>();

            Moq.Mock<IPizzaService> mockPizzasService = new Moq.Mock<IPizzaService>();
            mockPizzasService.Setup(x => x.MontarPizzas(pizzasDTOs)).ReturnsAsync(SelecionarPizzasPorQuantidade(1));

            List<Pizza> pizzas = await mockPizzasService.Object.MontarPizzas(pizzasDTOs);

            //Act
            Pedido pedido = new Pedido(data: DateTime.MinValue, pizzas: pizzas, enderecoId: null, clienteId: 1);

            // Assert
            pedido.IsValid.Should().BeFalse();
            pedido.Notifications.Should().HaveCount(1);
            pedido.Notifications.First(x => x.Key == "dataPedido").Message.Should().Be("Por favor digite uma data válida");
            pedido.Pizzas.Should().BeNull();     
        }


        [Fact(DisplayName = "Instanciar incorretamente um pedido - sem pizzas")]
        [Trait("Pedido", "Testes de criação de entidade de domínio de Pedido")]
        public async Task InstanciarPedidoIncorretamente_SemPizzas()
        {
            // Arrange
            List<Pizza> pizzas = new List<Pizza>();

            //Act
            Pedido pedido = new Pedido(data: DateTime.Now, pizzas: pizzas, enderecoId: null, clienteId: 1);

            // Assert
            pedido.IsValid.Should().BeFalse();
            pedido.Notifications.Should().HaveCount(2);
            pedido.Notifications.First(x => x.Key == "pizzaPedido").Message.Should().Be("Por favor passe pelo menos uma pizza para o pedido");
            pedido.Notifications.First(x => x.Key == "valorTotalPedido").Message.Should().Be("Foi encontrado um erro ao calcular o valor total desse pedido, ele tem que ser maior que zero");
            pedido.Pizzas.Should().BeNull();
            pedido.ValorTotal.Should().Be(0);
        }

        [Fact(DisplayName = "Instanciar incorretamente um pedido - mais de dez pizzas")]
        [Trait("Pedido", "Testes de criação de entidade de domínio de Pedido")]
        public async Task InstanciarPedidoIncorretamente_MaisDezPizzas()
        {
            // Arrange
            List<PizzaDTO> pizzasDTOs = new List<PizzaDTO>();

            Moq.Mock<IPizzaService> mockPizzasService = new Moq.Mock<IPizzaService>();
            mockPizzasService.Setup(x => x.MontarPizzas(pizzasDTOs)).ReturnsAsync(SelecionarPizzasPorQuantidade(15));

            List<Pizza> pizzas = await mockPizzasService.Object.MontarPizzas(pizzasDTOs);

            //Act
            Pedido pedido = new Pedido(data: DateTime.Now, pizzas: pizzas, enderecoId: null, clienteId: 1);

            // Assert
            pedido.IsValid.Should().BeFalse();
            pedido.Notifications.Should().HaveCount(1);
            pedido.Notifications.First(x => x.Key == "pizzaQtdePedido").Message.Should().Be("Por favor passe no máximo dez pizzas para o pedido");            
            pedido.Pizzas.Should().BeNull();           
        }

        [Fact(DisplayName = "Instanciar incorretamente um pedido - sem cliente e sem endereço")]
        [Trait("Pedido", "Testes de criação de entidade de domínio de Pedido")]
        public async Task InstanciarPedidoIncorretamente_SemCliente_SemEndereco()
        {
            // Arrange
            List<PizzaDTO> pizzasDTOs = new List<PizzaDTO>();

            Moq.Mock<IPizzaService> mockPizzasService = new Moq.Mock<IPizzaService>();
            mockPizzasService.Setup(x => x.MontarPizzas(pizzasDTOs)).ReturnsAsync(SelecionarPizzasPorQuantidade(15));

            List<Pizza> pizzas = await mockPizzasService.Object.MontarPizzas(pizzasDTOs);

            //Act
            Pedido pedido = new Pedido(data: DateTime.Now, pizzas: pizzas, enderecoId: null, clienteId: null);

            // Assert
            pedido.IsValid.Should().BeFalse();
            pedido.Notifications.Should().HaveCount(2);
            pedido.Notifications.First(x => x.Key == "enderecoOuClientePedido").Message.Should().Be("É necessário passar ou um endereço ou um cliente para o pedido");
            pedido.Pizzas.Should().BeNull();
        }

        [Fact(DisplayName = "Instanciar incorretamente um pedido - com cliente e com endereço")]
        [Trait("Pedido", "Testes de criação de entidade de domínio de Pedido")]
        public async Task InstanciarPedidoIncorretamente_ComCliente_ComEndereco()
        {
            // Arrange
            List<PizzaDTO> pizzasDTOs = new List<PizzaDTO>();

            Moq.Mock<IPizzaService> mockPizzasService = new Moq.Mock<IPizzaService>();
            mockPizzasService.Setup(x => x.MontarPizzas(pizzasDTOs)).ReturnsAsync(SelecionarPizzasPorQuantidade(15));

            List<Pizza> pizzas = await mockPizzasService.Object.MontarPizzas(pizzasDTOs);

            //Act
            Pedido pedido = new Pedido(data: DateTime.Now, pizzas: pizzas, enderecoId: 1, clienteId: 1);

            // Assert
            pedido.IsValid.Should().BeFalse();
            pedido.Notifications.Should().HaveCount(2);
            pedido.Notifications.First(x => x.Key == "enderecoEClientePedido").Message.Should().Be("Passe apenas um cliente, ou um endereço, não os dois parâmetros");
            pedido.Pizzas.Should().BeNull();
        }
    }
}
