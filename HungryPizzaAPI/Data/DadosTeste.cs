using HungryPizzaAPI.Models.Persistencias;
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

                SaborPersistencia tresQueijos = new SaborPersistencia { Descricao = "3 Queijos", Preco = 50M, EmFalta = false };
                SaborPersistencia frangoReq = new SaborPersistencia { Descricao = "Frango com requeijão", Preco = 59.99M, EmFalta = false };
                SaborPersistencia mussarela = new SaborPersistencia { Descricao = "Mussarela", Preco = 42.50M, EmFalta = false };
                SaborPersistencia calabresa = new SaborPersistencia { Descricao = "Calabresa", Preco = 42.50M, EmFalta = false };
                SaborPersistencia pepperoni = new SaborPersistencia { Descricao = "Pepperoni", Preco = 55M, EmFalta = true };
                SaborPersistencia portuguesa = new SaborPersistencia { Descricao = "Portuguesa", Preco = 45M, EmFalta = true };
                SaborPersistencia veggie = new SaborPersistencia { Descricao = "Veggie", Preco = 59.99M, EmFalta = false };


                PizzaPersistencia pizza1 = new PizzaPersistencia { Sabores = new List<SaborPersistencia> { tresQueijos, frangoReq }, PedidoId = null };
                pizza1.PrecoTotal = Queryable.Average(pizza1.Sabores.Select(x => x.Preco).AsQueryable());

                PizzaPersistencia pizza2 = new PizzaPersistencia { Sabores = new List<SaborPersistencia> { mussarela }, PedidoId = null };
                pizza2.PrecoTotal = Queryable.Average(pizza2.Sabores.Select(x => x.Preco).AsQueryable());

                PizzaPersistencia pizza3 = new PizzaPersistencia { Sabores = new List<SaborPersistencia> { calabresa }, PedidoId = null };
                pizza3.PrecoTotal = Queryable.Average(pizza3.Sabores.Select(x => x.Preco).AsQueryable());

                PizzaPersistencia pizza4 = new PizzaPersistencia { Sabores = new List<SaborPersistencia> { tresQueijos, calabresa }, PedidoId = null };
                pizza4.PrecoTotal = Queryable.Average(pizza4.Sabores.Select(x => x.Preco).AsQueryable());

                PizzaPersistencia pizza5 = new PizzaPersistencia { Sabores = new List<SaborPersistencia> { calabresa }, PedidoId = null };
                pizza5.PrecoTotal = Queryable.Average(pizza5.Sabores.Select(x => x.Preco).AsQueryable());

                PizzaPersistencia pizza6 = new PizzaPersistencia { Sabores = new List<SaborPersistencia> { mussarela }, PedidoId = null };
                pizza6.PrecoTotal = Queryable.Average(pizza6.Sabores.Select(x => x.Preco).AsQueryable());

                PizzaPersistencia pizza7 = new PizzaPersistencia { Sabores = new List<SaborPersistencia> { calabresa }, PedidoId = null };
                pizza7.PrecoTotal = Queryable.Average(pizza7.Sabores.Select(x => x.Preco).AsQueryable());

                PizzaPersistencia pizza8 = new PizzaPersistencia { Sabores = new List<SaborPersistencia> { mussarela }, PedidoId = null };
                pizza8.PrecoTotal = Queryable.Average(pizza8.Sabores.Select(x => x.Preco).AsQueryable());

                PizzaPersistencia pizza9 = new PizzaPersistencia { Sabores = new List<SaborPersistencia> { calabresa }, PedidoId = null };
                pizza9.PrecoTotal = Queryable.Average(pizza9.Sabores.Select(x => x.Preco).AsQueryable());

                PizzaPersistencia pizza10 = new PizzaPersistencia { Sabores = new List<SaborPersistencia> { mussarela }, PedidoId = null };
                pizza10.PrecoTotal = Queryable.Average(pizza10.Sabores.Select(x => x.Preco).AsQueryable());

                PizzaPersistencia pizza11 = new PizzaPersistencia { Sabores = new List<SaborPersistencia> { calabresa }, PedidoId = null };
                pizza11.PrecoTotal = Queryable.Average(pizza11.Sabores.Select(x => x.Preco).AsQueryable());

                PizzaPersistencia pizza12 = new PizzaPersistencia { Sabores = new List<SaborPersistencia> { mussarela }, PedidoId = null };
                pizza12.PrecoTotal = Queryable.Average(pizza12.Sabores.Select(x => x.Preco).AsQueryable());

                PizzaPersistencia pizza13 = new PizzaPersistencia { Sabores = new List<SaborPersistencia> { calabresa }, PedidoId = null };
                pizza13.PrecoTotal = Queryable.Average(pizza13.Sabores.Select(x => x.Preco).AsQueryable());

                PizzaPersistencia pizza14 = new PizzaPersistencia { Sabores = new List<SaborPersistencia> { tresQueijos, frangoReq }, PedidoId = null };
                pizza14.PrecoTotal = Queryable.Average(pizza14.Sabores.Select(x => x.Preco).AsQueryable());

                PizzaPersistencia pizza15 = new PizzaPersistencia { Sabores = new List<SaborPersistencia> { tresQueijos, calabresa }, PedidoId = null };
                pizza15.PrecoTotal = Queryable.Average(pizza15.Sabores.Select(x => x.Preco).AsQueryable());

                context.AddRange(pizza1, pizza2, pizza3, pizza4, pizza5, pizza6, pizza7, pizza8, pizza9, pizza10, pizza11, pizza12, pizza13, pizza14, pizza15);                       

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
                    new EnderecoPersistencia { Rua = "Rua Teste 1", CEP = "00000-000", Cidade = "São Paulo", Estado = "SP" },
                    new EnderecoPersistencia { Rua = "Rua Teste 2", CEP = "11111-111", Cidade = "São Paulo", Estado = "SP" },
                    new EnderecoPersistencia { Rua = "Rua Teste 3", CEP = "22222-222", Cidade = "São Paulo", Estado = "SP" },
                    new EnderecoPersistencia { Rua = "Rua Teste 4", CEP = "44444-444", Cidade = "São Paulo", Estado = "SP" },
                    new EnderecoPersistencia { Rua = "Rua Teste 5", CEP = "55555-555", Cidade = "São Paulo", Estado = "SP" }
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
                    new ClientePersistencia { Nome = "Cliente Teste 1", EnderecoId = 1 },
                    new ClientePersistencia { Nome = "Cliente Teste 2", EnderecoId = 2 },
                    new ClientePersistencia { Nome = "Cliente Teste 3", EnderecoId = 3 }
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

                PedidoPersistencia pedido1 = new PedidoPersistencia { Data = DateTime.Now, Pizzas = pizzas.Where(x => x.Id == 1).ToList(), EnderecoId = 4, ClienteId = null };
                pedido1.ValorTotal = Queryable.Sum(pedido1.Pizzas.Select(x => x.PrecoTotal).AsQueryable());

                PedidoPersistencia pedido2 = new PedidoPersistencia { Data = DateTime.Now, Pizzas = pizzas.Where(x => x.Id >= 2 && x.Id <= 3).ToList(), EnderecoId = null, ClienteId = 1 };
                pedido2.ValorTotal = Queryable.Sum(pedido2.Pizzas.Select(x => x.PrecoTotal).AsQueryable());

                PedidoPersistencia pedido3 = new PedidoPersistencia { Data = DateTime.Now, Pizzas = pizzas.Where(x => x.Id == 4).ToList(), EnderecoId = null, ClienteId = 2 };
                pedido3.ValorTotal = Queryable.Sum(pedido3.Pizzas.Select(x => x.PrecoTotal).AsQueryable());

                PedidoPersistencia pedido4 = new PedidoPersistencia { Data = DateTime.Now, Pizzas = pizzas.Where(x => x.Id == 5).ToList(), EnderecoId = null, ClienteId = 2 };
                pedido4.ValorTotal = Queryable.Sum(pedido4.Pizzas.Select(x => x.PrecoTotal).AsQueryable());

                PedidoPersistencia pedido5 = new PedidoPersistencia { Data = DateTime.Now, Pizzas = pizzas.Where(x => x.Id == 6).ToList(), EnderecoId = null, ClienteId = 2 };
                pedido5.ValorTotal = Queryable.Sum(pedido5.Pizzas.Select(x => x.PrecoTotal).AsQueryable());

                PedidoPersistencia pedido6 = new PedidoPersistencia { Data = DateTime.Now, Pizzas = pizzas.Where(x => x.Id == 7).ToList(), EnderecoId = null, ClienteId = 2 };
                pedido6.ValorTotal = Queryable.Sum(pedido6.Pizzas.Select(x => x.PrecoTotal).AsQueryable());

                PedidoPersistencia pedido7 = new PedidoPersistencia { Data = DateTime.Now, Pizzas = pizzas.Where(x => x.Id == 8).ToList(), EnderecoId = null, ClienteId = 2 };
                pedido7.ValorTotal = Queryable.Sum(pedido7.Pizzas.Select(x => x.PrecoTotal).AsQueryable());

                PedidoPersistencia pedido8 = new PedidoPersistencia { Data = DateTime.Now, Pizzas = pizzas.Where(x => x.Id == 9).ToList(), EnderecoId = 4, ClienteId = null };
                pedido8.ValorTotal = Queryable.Sum(pedido8.Pizzas.Select(x => x.PrecoTotal).AsQueryable());

                PedidoPersistencia pedido9 = new PedidoPersistencia { Data = DateTime.Now, Pizzas = pizzas.Where(x => x.Id == 10).ToList(), EnderecoId = 4, ClienteId = null };
                pedido9.ValorTotal = Queryable.Sum(pedido9.Pizzas.Select(x => x.PrecoTotal).AsQueryable());

                PedidoPersistencia pedido10 = new PedidoPersistencia { Data = DateTime.Now, Pizzas = pizzas.Where(x => x.Id == 11).ToList(), EnderecoId = 4, ClienteId = null };
                pedido10.ValorTotal = Queryable.Sum(pedido10.Pizzas.Select(x => x.PrecoTotal).AsQueryable());

                PedidoPersistencia pedido11 = new PedidoPersistencia { Data = DateTime.Now, Pizzas = pizzas.Where(x => x.Id >= 12 && x.Id <= 15).ToList(), EnderecoId = null, ClienteId = 2 };
                pedido11.ValorTotal = Queryable.Sum(pedido11.Pizzas.Select(x => x.PrecoTotal).AsQueryable());


                context.Pedidos.AddRange(pedido1, pedido2, pedido3, pedido4, pedido5, pedido6, pedido7, pedido8, pedido9, pedido10, pedido11);

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Já existem dados de pedidos no banco");
            }
        }
    }
}
