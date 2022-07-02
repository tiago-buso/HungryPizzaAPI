namespace HungryPizzaAPI.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public string IdentificadorUnico => $"{Data.ToString("yyyyMMdd")}{Id}";

        public List<Pizza> Pizzas { get; set; }
        public double ValorTotal => CalcularValorTotal();

        private double CalcularValorTotal()
        {
            if (Pizzas == null || (Pizzas != null && Pizzas.Any()))
            {
                throw new ArgumentException("Erro de falta de pizzas");
            }

            double valorTotal = Queryable.Average(Pizzas.Select(x => x.PrecoTotal).AsQueryable());
            return valorTotal;
        }

        public Endereco EnderecoEntrega { get; set; }
        public Cliente ClienteEntrega { get; set; }
    }
}
