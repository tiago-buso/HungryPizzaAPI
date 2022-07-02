using HungryPizzaAPI.Models;

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
            InserirDadosTesteSabores(context);
            InserirDadosTesteEnderecos(context);
            InserirDadosTesteClientes(context);
        }

        private static void InserirDadosTesteSabores(APIDbContext context)
        {
            if (!context.Sabores.Any())
            {
                Console.WriteLine("--> Inserindo dados teste de Sabores...");

                context.Sabores.AddRange(
                    new Sabor(descricao: "3 Queijos", preco: 50M, emFalta: false),
                    new Sabor(descricao: "Frango com requeijão", preco: 59.99M, emFalta: false ),
                    new Sabor(descricao: "Mussarela", preco: 42.50M, emFalta: false ),
                    new Sabor(descricao: "Calabresa", preco: 42.50M, emFalta: false ),
                    new Sabor(descricao: "Pepperoni", preco: 55M, emFalta: true ),
                    new Sabor(descricao: "Portuguesa", preco: 45M, emFalta: true ),
                    new Sabor(descricao: "Veggie", preco: 59.99M, emFalta: false )
                    );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Já existem dados de sabores no banco");
            }
        }

        private static void InserirDadosTesteEnderecos(APIDbContext context)
        {
            if (!context.Enderecos.Any())
            {
                Console.WriteLine("--> Inserindo dados teste de Endereços...");

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
                Console.WriteLine("--> Inserindo dados teste de Clientes...");

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

        //private static void InserirDadosTestePizzas(APIDbContext context)
        //{
        //    if (!context.Pizzas.Any())
        //    {
        //        Console.WriteLine("--> Inserindo dados teste de Pizzas...");

        //        context.Pizzas.AddRange(
        //            new Pizzas(),
        //            new Pizzas(),
        //            new Pizzas()
        //            );

        //        context.SaveChanges();
        //    }
        //    else
        //    {
        //        Console.WriteLine("--> Já existem dados de clientes no banco");
        //    }
        //}
    }
}
