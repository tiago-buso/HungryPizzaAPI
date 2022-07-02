namespace HungryPizzaAPI.Models
{
    public class Pizza
    {       

        public int Id { get; private set; }
        public IList<Sabor> Sabores { get; private set; }
        public decimal PrecoTotal { get; private set; }

        public int? PedidoId { get; private set; }
        public Pedido Pedido { get; private set; }

        public Pizza()
        {
        }

        public Pizza(IList<Sabor> sabores, int? pedidoId)
        {
            Sabores = sabores;
            PrecoTotal = CalcularPrecoTotal();
            PedidoId = pedidoId;            
        }

        private decimal CalcularPrecoTotal()
        {
            if (Sabores == null || (Sabores != null && !Sabores.Any()))
            {
                throw new ArgumentException("Erro de falta de sabores");
            }

            decimal precoTotal = Queryable.Average(Sabores.Select(x => x.Preco).AsQueryable());
            return precoTotal;
        }
    }
}
