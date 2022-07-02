namespace HungryPizzaAPI.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
