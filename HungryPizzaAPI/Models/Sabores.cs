namespace HungryPizzaAPI.Models
{
    public class Sabores
    {   
        public int Id { get; set; }
      
        public string Descricao { get; set; }
     
        public decimal Preco { get; set; }
       
        public bool EmFalta { get; set; } = false;

        public ICollection<Pizza> Pizzas { get; set; }
    }
}
