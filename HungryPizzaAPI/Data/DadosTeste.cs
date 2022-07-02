using HungryPizzaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HungryPizzaAPI.Data
{
    public class DadosTeste
    {
        public static void PrepararDadosTeste(WebApplication app)
        {

            using (var serviceScope = app.Services.CreateScope())
            {
                InserirDadosTeste(serviceScope.ServiceProvider.GetService<APIDbContext>());
            }
        }

        private static void InserirDadosTeste(APIDbContext context)
        {
            AplicarMigrations(context);
            InserirDadosTesteSaboresEPizzas(context);
            InserirDadosTesteEnderecos(context);
            InserirDadosTesteClientes(context);
            InserirDadosTestePedidos(context);
        }

        private static void AplicarMigrations(APIDbContext context)
        {
            Console.WriteLine("--> Tentando aplicar as migrações ...");

            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Não conseguiu aplicar as migrações {ex.Message}");
            }
        }

        private static void InserirDadosTesteSaboresEPizzas(APIDbContext context)
        {
            if (!context.Sabores.Any())
            {
                Console.WriteLine("--> Inserindo dados teste de sabores e pizzas...");

                Sabor tresQueijos = new Sabor(descricao: "3 Queijos", preco: 50M, emFalta: false);
                Sabor frangoReq = new Sabor(descricao: "Frango com requeijão", preco: 59.99M, emFalta: false);
                Sabor mussarela = new Sabor(descricao: "Mussarela", preco: 42.50M, emFalta: false);
                Sabor calabresa = new Sabor(descricao: "Calabresa", preco: 42.50M, emFalta: false);
                Sabor pepperoni = new Sabor(descricao: "Pepperoni", preco: 55M, emFalta: true);
                Sabor portuguesa = new Sabor(descricao: "Portuguesa", preco: 45M, emFalta: true);
                Sabor veggie = new Sabor(descricao: "Veggie", preco: 59.99M, emFalta: false);


                context.AddRange(
                            new Pizza(sabores: new List<Sabor> { tresQueijos, frangoReq }, pedidoId: null),
                            new Pizza(sabores: new List<Sabor> { mussarela }, pedidoId: null),
                            new Pizza(sabores: new List<Sabor> { calabresa }, pedidoId: null),
                            new Pizza(sabores: new List<Sabor> { tresQueijos, calabresa }, pedidoId: null),
                            new Pizza(sabores: new List<Sabor> { calabresa }, pedidoId: null)
                        );

                context.Sabores.AddRange(
                    pepperoni,
                    portuguesa,
                    veggie
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Já existem dados de sabores e pizzas no banco");
            }
        }

        private static void InserirDadosTesteEnderecos(APIDbContext context)
        {
            if (!context.Enderecos.Any())
            {
                Console.WriteLine("--> Inserindo dados teste de endereços...");

                context.Enderecos.AddRange(
                    new Endereco(rua: "Rua Teste 1", cep: "00000-000", cidade: "São Paulo", estado: "SP"),
                    new Endereco(rua: "Rua Teste 2", cep: "11111-111", cidade: "São Paulo", estado: "SP"),
                    new Endereco(rua: "Rua Teste 3", cep: "22222-222", cidade: "São Paulo", estado: "SP"),
                    new Endereco(rua: "Rua Teste 4", cep: "44444-444", cidade: "São Paulo", estado: "SP"),
                    new Endereco(rua: "Rua Teste 5", cep: "55555-555", cidade: "São Paulo", estado: "SP")
                    );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Já existem dados de endereços no banco");
            }
        }

        private static void InserirDadosTesteClientes(APIDbContext context)
        {
            if (!context.Clientes.Any())
            {
                Console.WriteLine("--> Inserindo dados teste de clientes...");

                context.Clientes.AddRange(
                    new Cliente(nome: "Cliente Teste 1", enderecoId: 1),
                    new Cliente(nome: "Cliente Teste 2", enderecoId: 2),
                    new Cliente(nome: "Cliente Teste 3", enderecoId: 3)
                    );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Já existem dados de clientes no banco");
            }
        }

        private static void InserirDadosTestePedidos(APIDbContext context)
        {
            if (!context.Pedidos.Any())
            {
                Console.WriteLine("--> Inserindo dados teste de pedidos...");

                var pizzas = context.Pizzas.ToList();

                context.Pedidos.AddRange(
                    new Pedido(data: DateTime.Now, pizzas: pizzas.Where(x => x.Id == 1).ToList(), enderecoId: 4, clienteId: null),
                    new Pedido(data: DateTime.Now, pizzas: pizzas.Where(x => x.Id >= 2 && x.Id <= 3).ToList(), enderecoId: null, clienteId: 1),
                    new Pedido(data: DateTime.Now, pizzas: pizzas.Where(x => x.Id >= 4).ToList(), enderecoId: null, clienteId: 2)
                    );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Já existem dados de pedidos no banco");
            }
        }
    }
}
