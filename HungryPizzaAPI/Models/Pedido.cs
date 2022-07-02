namespace HungryPizzaAPI.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public string IdentificadorUnico => $"{Data.ToString("yyyyMMdd")}{Id}";

        public ICollection<Pizza> Pizzas { get; set; }
        public decimal ValorTotal => CalcularValorTotal();

        private decimal CalcularValorTotal()
        {
            if (Pizzas == null || (Pizzas != null && Pizzas.Any()))
            {
                throw new ArgumentException("Erro de falta de pizzas");
            }

            decimal valorTotal = Queryable.Average(Pizzas.Select(x => x.PrecoTotal).AsQueryable());
            return valorTotal;
        }

        public int? EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
