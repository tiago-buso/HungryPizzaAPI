namespace HungryPizzaAPI.Models
{
    public class Pedido
    {
        public int Id { get; private set; }

        public DateTime Data { get; private set; }

        public string IdentificadorUnico { get; private set; } 

        public ICollection<Pizza> Pizzas { get; private set; }
        public decimal ValorTotal { get; private set; }       

        public int? EnderecoId { get; private set; }
        public Endereco Endereco { get; private set; }

        public int? ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }      

        public Pedido()
        {
        }

        public Pedido(int id, DateTime data, string identificadorUnico, ICollection<Pizza> pizzas, decimal valorTotal, int? enderecoId, Endereco endereco, int? clienteId, Cliente cliente)
        {
            Id = id;
            Data = data;
            IdentificadorUnico = identificadorUnico;
            Pizzas = pizzas;
            ValorTotal = valorTotal;
            EnderecoId = enderecoId;
            Endereco = endereco;
            ClienteId = clienteId;
            Cliente = cliente;
        }

        public string ObteridentificadorUnico()
        {
            return $"{Data.ToString("yyyyMMdd")}{Id}";
        }

        private decimal CalcularValorTotal()
        {
            if (Pizzas == null || (Pizzas != null && Pizzas.Any()))
            {
                throw new ArgumentException("Erro de falta de pizzas");
            }

            decimal valorTotal = Queryable.Average(Pizzas.Select(x => x.PrecoTotal).AsQueryable());
            return valorTotal;
        }

    }
}
