namespace HungryPizzaAPI.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public List<Sabores> Sabores { get; set; }
        public double PrecoTotal => CalcularPrecoTotal();

        private double CalcularPrecoTotal()
        {
            if (Sabores == null || (Sabores != null && Sabores.Any()))
            {
                throw new ArgumentException("Erro de falta de sabores");
            }

            double precoTotal = Queryable.Average(Sabores.Select(x => x.Preco).AsQueryable());
            return precoTotal;
        }
    }
}
