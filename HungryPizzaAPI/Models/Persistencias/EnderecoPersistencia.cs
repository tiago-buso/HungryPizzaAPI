namespace HungryPizzaAPI.Models.Persistencias
{
    public class EnderecoPersistencia
    {
        public int Id { get; set; }

        public string Rua { get; set; }

        public string CEP { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public virtual ClientePersistencia Cliente { get; set; }

        public ICollection<PedidoPersistencia> Pedidos { get; set; }
    }
}
