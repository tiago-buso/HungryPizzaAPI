namespace HungryPizzaAPI.Models
{
    public class PizzaSabor
    {
        public int PizzaId { get; private set; }
        public Pizza Pizza { get; private set; }

        public int SaborId { get; private set; }
        public Sabor Sabor { get; private set; }

        public PizzaSabor()
        {
        }

        public PizzaSabor(int pizzaId, Pizza pizza, int saborId, Sabor sabor)
        {
            PizzaId = pizzaId;
            Pizza = pizza;
            SaborId = saborId;
            Sabor = sabor;
        }
    }
}
