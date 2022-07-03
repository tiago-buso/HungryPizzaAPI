namespace HungryPizzaAPI.Models.DTOs
{
    public class PedidoDTO
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public int QuantidadePizzas { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
