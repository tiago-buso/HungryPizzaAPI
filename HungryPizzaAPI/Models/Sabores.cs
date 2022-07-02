namespace HungryPizzaAPI.Models
{
    public class Sabores
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public bool EmFalta { get; set; } = false;
    }
}
