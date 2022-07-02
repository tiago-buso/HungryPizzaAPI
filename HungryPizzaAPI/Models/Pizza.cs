namespace HungryPizzaAPI.Models
{
    public class Pizza
    {       

        public int Id { get; private set; }
        public IList<PizzaSabor> PizzaSabores { get; private set; }
        public decimal PrecoTotal { get; private set; }

        public int? PedidoId { get; private set; }
        public Pedido Pedido { get; private set; }

        public Pizza()
        {
        }

        public Pizza(IList<PizzaSabor> pizzaSabores, int? pedidoId)
        {         
            PizzaSabores = pizzaSabores;
            PrecoTotal = CalcularPrecoTotal();
            PedidoId = pedidoId;            
        }

        private decimal CalcularPrecoTotal()
        {
            if (PizzaSabores == null || (PizzaSabores != null && PizzaSabores.Any()))
            {
                throw new ArgumentException("Erro de falta de sabores");
            }

            decimal precoTotal = Queryable.Average(PizzaSabores.Select(x => x.Sabor.Preco).AsQueryable());
            return precoTotal;
        }
    }
}
