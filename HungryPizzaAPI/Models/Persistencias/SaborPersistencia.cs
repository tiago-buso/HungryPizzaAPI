namespace HungryPizzaAPI.Models.Persistencias
{
    public class SaborPersistencia
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public bool EmFalta { get; set; }

        public IList<PizzaPersistencia> Pizzas { get; set; }
    }
}
