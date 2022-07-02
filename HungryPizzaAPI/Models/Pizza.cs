namespace HungryPizzaAPI.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public List<Sabores> Sabores { get; set; }
        public decimal PrecoTotal => CalcularPrecoTotal();

        private decimal CalcularPrecoTotal()
        {
            if (Sabores == null || (Sabores != null && Sabores.Any()))
            {
                throw new ArgumentException("Erro de falta de sabores");
            }

            decimal precoTotal = Queryable.Average(Sabores.Select(x => x.Preco).AsQueryable());
            return precoTotal;
        }
    }
}
