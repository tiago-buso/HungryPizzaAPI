namespace HungryPizzaAPI.Models
{
    public class Pedido
    {
        public int Id { get; private set; }

        public DateTime Data { get; private set; }        

        public ICollection<Pizza> Pizzas { get; private set; }
        public decimal ValorTotal { get; private set; }       

        public int? EnderecoId { get; private set; }
        public Endereco Endereco { get; private set; }

        public int? ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }      

        public Pedido()
        {
        }

        public Pedido(DateTime data, ICollection<Pizza> pizzas, int? enderecoId, int? clienteId)
        {            
            Data = data;            
            Pizzas = pizzas;
            ValorTotal = CalcularValorTotal();
            EnderecoId = enderecoId;          
            ClienteId = clienteId;          
        }

        private decimal CalcularValorTotal()
        {
            if (Pizzas == null || (Pizzas != null && !Pizzas.Any()))
            {
                throw new ArgumentException("Erro de falta de pizzas");
            }

            decimal valorTotal = Queryable.Average(Pizzas.Select(x => x.PrecoTotal).AsQueryable());
            return valorTotal;
        }

    }
}
