namespace HungryPizzaAPI.Models
{
    public class Cliente
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }

        public int EnderecoId { get; private set; }
        public virtual Endereco Endereco { get; private set; }

        public ICollection<Pedido> Pedidos { get; private set; }

        public Cliente()
        {
        }

        public Cliente(string nome, int enderecoId)
        {           
            Nome = nome;
            EnderecoId = enderecoId;             
        }
    }
}
