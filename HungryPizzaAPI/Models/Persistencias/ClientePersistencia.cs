namespace HungryPizzaAPI.Models.Persistencias
{
    public class ClientePersistencia
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public int EnderecoId { get; set; }
        public virtual EnderecoPersistencia Endereco { get; set; }

        public ICollection<PedidoPersistencia> Pedidos { get; set; }
    }
}
