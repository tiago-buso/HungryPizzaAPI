using FluentAssertions;
using HungryPizzaAPI.Models.Dominios;
using HungryPizzaAPI.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizzaTest
{
    public class PizzaTest
    {

        private List<Sabor> SelecionarSaboresPorQuantidadeESeEstaEmFalta(int quantidade, bool? emFalta = null)
        {
            List<Sabor> sabores = new List<Sabor>();

            sabores.Add(new Sabor(descricao: "3 Queijos", preco: 50M, emFalta: false));
            sabores.Add(new Sabor(descricao: "Frango com requeijão", preco: 59.99M, emFalta: false));
            sabores.Add(new Sabor(descricao: "Mussarela", preco: 42.50M, emFalta: false));
            sabores.Add(new Sabor(descricao: "Calabresa", preco: 42.50M, emFalta: false));
            sabores.Add(new Sabor(descricao: "Pepperoni", preco: 55M, emFalta: true));
            sabores.Add(new Sabor(descricao: "Portuguesa", preco: 45M, emFalta: true));
            sabores.Add(new Sabor(descricao: "Veggie", preco: 59.99M, emFalta: false));

            if (emFalta.HasValue && emFalta.Value)
            {
                return sabores.Where(x => x.EmFalta).Skip(0).Take(quantidade).ToList();
            }

            return sabores.Skip(0).Take(quantidade).ToList();
        }       

        [Fact(DisplayName = "Instanciar corretamente uma pizza - 1 sabor")]
        [Trait("Pizza", "Testes de criação de entidade de domínio de Pizza")]
        public async Task InstanciarPizzaCorretamente_Umsabor()
        {
            // Arrange
            List<int> saboresIds = new List<int> { 1 };

            Moq.Mock<ISaboresService> mockSaboresService = new Moq.Mock<ISaboresService>();
            mockSaboresService.Setup(x => x.SelecionarSaboresPorIds(saboresIds)).ReturnsAsync(SelecionarSaboresPorQuantidadeESeEstaEmFalta(1));

            List<Sabor> sabores = await mockSaboresService.Object.SelecionarSaboresPorIds(saboresIds);

            //Act
            Pizza pizza = new Pizza(sabores: sabores, pedidoId: null);

            // Assert
            pizza.IsValid.Should().BeTrue();
            pizza.Notifications.Should().HaveCount(0);
            pizza.Sabores.Count().Should().Be(1);
        }

        [Fact(DisplayName = "Instanciar corretamente uma pizza - 2 sabores")]
        [Trait("Pizza", "Testes de criação de entidade de domínio de Pizza")]
        public async Task InstanciarPizzaCorretamente_DoisSabores()
        {
            // Arrange
            List<int> saboresIds = new List<int> { 1, 2 };

            Moq.Mock<ISaboresService> mockSaboresService = new Moq.Mock<ISaboresService>();
            mockSaboresService.Setup(x => x.SelecionarSaboresPorIds(saboresIds)).ReturnsAsync(SelecionarSaboresPorQuantidadeESeEstaEmFalta(2));

            List<Sabor> sabores = await mockSaboresService.Object.SelecionarSaboresPorIds(saboresIds);

            //Act
            Pizza pizza = new Pizza(sabores: sabores, pedidoId: null);

            // Assert
            pizza.IsValid.Should().BeTrue();
            pizza.Notifications.Should().HaveCount(0);
            pizza.Sabores.Count().Should().Be(2);
        }

        [Fact(DisplayName = "Instanciar corretamente uma pizza - 1 sabor - calcular preço total")]
        [Trait("Pizza", "Testes de criação de entidade de domínio de Pizza")]
        public async Task InstanciarPizzaCorretamente_UmSabor_CalcularPreco()
        {
            // Arrange
            List<int> saboresIds = new List<int> { 1 };
            var saboresMock = SelecionarSaboresPorQuantidadeESeEstaEmFalta(1);

            Moq.Mock<ISaboresService> mockSaboresService = new Moq.Mock<ISaboresService>();
            mockSaboresService.Setup(x => x.SelecionarSaboresPorIds(saboresIds)).ReturnsAsync(saboresMock);

            List<Sabor> sabores = await mockSaboresService.Object.SelecionarSaboresPorIds(saboresIds);

            //Act
            Pizza pizza = new Pizza(sabores: sabores, pedidoId: null);

            // Assert
            pizza.IsValid.Should().BeTrue();
            pizza.Notifications.Should().HaveCount(0);
            pizza.Sabores.Count().Should().Be(1);
            pizza.PrecoTotal.Should().Be(saboresMock.First().Preco);
        }


        [Fact(DisplayName = "Instanciar corretamente uma pizza - 2 sabores - calcular preço total")]
        [Trait("Pizza", "Testes de criação de entidade de domínio de Pizza")]
        public async Task InstanciarPizzaCorretamente_DoisSabores_CalcularPreco()
        {
            // Arrange
            List<int> saboresIds = new List<int> { 1, 2 };
            var saboresMock = SelecionarSaboresPorQuantidadeESeEstaEmFalta(2);

            Moq.Mock<ISaboresService> mockSaboresService = new Moq.Mock<ISaboresService>();
            mockSaboresService.Setup(x => x.SelecionarSaboresPorIds(saboresIds)).ReturnsAsync(saboresMock);

            List<Sabor> sabores = await mockSaboresService.Object.SelecionarSaboresPorIds(saboresIds);

            //Act
            Pizza pizza = new Pizza(sabores: sabores, pedidoId: null);

            // Assert
            pizza.IsValid.Should().BeTrue();
            pizza.Notifications.Should().HaveCount(0);
            pizza.Sabores.Count().Should().Be(2);
            pizza.PrecoTotal.Should().Be(54.995M);
        }

        [Fact(DisplayName = "Instanciar inccorretamente uma pizza - 0 sabor")]
        [Trait("Pizza", "Testes de criação de entidade de domínio de Pizza")]
        public async Task InstanciarPizzaIncorretamente_ZeroSabor()
        {
            // Arrange            
            List<Sabor> sabores = new List<Sabor>();

            //Act
            Pizza pizza = new Pizza(sabores: sabores, pedidoId: null);

            // Assert
            pizza.IsValid.Should().BeFalse();
            pizza.Notifications.Should().HaveCount(2);
            pizza.Notifications.First(x => x.Key == "saboresPizza").Message.Should().Be("Por favor passe pelo menos um sabor para a pizza");
            pizza.Notifications.First(x => x.Key == "precoTotalPizza").Message.Should().Be("Foi encontrado um erro ao calcular o preço total dessa pizza, ele tem que ser maior que zero");
            pizza.Sabores.Should().BeNull();
            pizza.PrecoTotal.Should().Be(0);
        }

        [Fact(DisplayName = "Instanciar inccorretamente uma pizza - sabor em falta")]
        [Trait("Pizza", "Testes de criação de entidade de domínio de Pizza")]
        public async Task InstanciarPizzaIncorretamente_SaborEmFalta()
        {
            // Arrange            
            List<int> saboresIds = new List<int> { 1 };
            var saboresMock = SelecionarSaboresPorQuantidadeESeEstaEmFalta(1, true);

            Moq.Mock<ISaboresService> mockSaboresService = new Moq.Mock<ISaboresService>();
            mockSaboresService.Setup(x => x.SelecionarSaboresPorIds(saboresIds)).ReturnsAsync(saboresMock);

            List<Sabor> sabores = await mockSaboresService.Object.SelecionarSaboresPorIds(saboresIds);

            //Act
            Pizza pizza = new Pizza(sabores: sabores, pedidoId: null);

            // Assert
            pizza.IsValid.Should().BeFalse();
            pizza.Notifications.Should().HaveCount(1);
            pizza.Notifications.First(x => x.Key == "saboresEmFaltaPizza").Message.Should().NotBeEmpty();            
            pizza.Sabores.Should().BeNull();            
        }

        [Fact(DisplayName = "Instanciar inccorretamente uma pizza - vários sabores e pelo menos um em falta")]
        [Trait("Pizza", "Testes de criação de entidade de domínio de Pizza")]
        public async Task InstanciarPizzaIncorretamente_PeloMenosUmSaborEmFalta()
        {
            // Arrange            
            List<int> saboresIds = new List<int> { 1 };
            var saboresMock = SelecionarSaboresPorQuantidadeESeEstaEmFalta(7, true);

            Moq.Mock<ISaboresService> mockSaboresService = new Moq.Mock<ISaboresService>();
            mockSaboresService.Setup(x => x.SelecionarSaboresPorIds(saboresIds)).ReturnsAsync(saboresMock);

            List<Sabor> sabores = await mockSaboresService.Object.SelecionarSaboresPorIds(saboresIds);

            //Act
            Pizza pizza = new Pizza(sabores: sabores, pedidoId: null);

            // Assert
            pizza.IsValid.Should().BeFalse();
            pizza.Notifications.Should().HaveCount(1);
            pizza.Notifications.First(x => x.Key == "saboresEmFaltaPizza").Message.Should().NotBeEmpty();
            pizza.Sabores.Should().BeNull();
        }
    }
}
