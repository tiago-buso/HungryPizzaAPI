namespace HungryPizzaAPI.Models.Persistencias
{
    public class PizzaPersistencia
    {
        public int Id { get; set; }
        public IList<SaborPersistencia> Sabores { get; set; }
        public decimal PrecoTotal { get; set; }

        public int? PedidoId { get; set; }
        public PedidoPersistencia Pedido { get; set; }
    }
}
