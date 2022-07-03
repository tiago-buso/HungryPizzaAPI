using System.ComponentModel.DataAnnotations.Schema;

namespace HungryPizzaAPI.Models.Persistencias
{
    public class PedidoPersistencia
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public ICollection<PizzaPersistencia> Pizzas { get; set; }

        [NotMapped]
        public int QuantidadePizzas => Pizzas.Count;
        public decimal ValorTotal { get; set; }

        public int? EnderecoId { get; set; }
        public EnderecoPersistencia Endereco { get; set; }

        public int? ClienteId { get; set; }
        public ClientePersistencia Cliente { get; set; }
    }
}
