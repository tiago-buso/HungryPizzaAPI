namespace HungryPizzaAPI.Models
{
    public class Sabor
    {   
        public int Id { get; private set; }
      
        public string Descricao { get; private set; }
     
        public decimal Preco { get; private set; }
       
        public bool EmFalta { get; private set; } = false;

        public IList<Pizza> Pizzas { get; private set; }

        public Sabor()
        {
        }

        public Sabor(string descricao, decimal preco, bool emFalta)
        {          
            Descricao = descricao;
            Preco = preco;
            EmFalta = emFalta;           
        }
    }
}
