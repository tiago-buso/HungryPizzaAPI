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

        }

        private static void InserirDadosTesteSabores(APIDbContext context)
        {
            if (!context.Sabores.Any())
            {
                Console.WriteLine("--> Inserindo dados teste de Sabores...");

                context.Sabores.AddRange(
                    new Sabores() { Descricao = "3 Queijos", Preco = 50M, EmFalta = false },
                    new Sabores() { Descricao = "Frango com requeijão", Preco = 59.99M, EmFalta = false },
                    new Sabores() { Descricao = "Mussarela", Preco = 42.50M, EmFalta = false },
                    new Sabores() { Descricao = "Calabresa", Preco = 42.50M, EmFalta = false },
                    new Sabores() { Descricao = "Pepperoni", Preco = 55M, EmFalta = true },
                    new Sabores() { Descricao = "Portuguesa", Preco = 45M, EmFalta = true },
                    new Sabores() { Descricao = "Veggie", Preco = 59.99M, EmFalta = false }
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
            if (!context.Sabores.Any())
            {
                Console.WriteLine("--> Inserindo dados teste de Endereços...");

                context.Enderecos.AddRange(
                    new Endereco() { Rua = "Rua Teste 1", CEP = "00000-000", Cidade = "São Paulo", Estado = "SP"},
                    new Endereco() { Rua = "Rua Teste 2", CEP = "11111-111", Cidade = "São Paulo", Estado = "SP" },
                    new Endereco() { Rua = "Rua Teste 3", CEP = "22222-222", Cidade = "São Paulo", Estado = "SP" }                    
                    );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Já existem dados de endereços no banco");
            }
        }
    }
}
