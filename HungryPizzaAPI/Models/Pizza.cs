using Flunt.Notifications;

namespace HungryPizzaAPI.Models
{
    public class Pizza : Notifiable<Notification>
    {       

        public int Id { get; private set; }
        public IList<Sabor> Sabores { get; private set; }
        public decimal PrecoTotal { get; private set; }

        public int? PedidoId { get; private set; }
        public Pedido Pedido { get; private set; }

        public Pizza()
        {
        }

        public Pizza(IList<Sabor> sabores, int? pedidoId)
        {
            ValidarSabores(sabores);
            CalcularPrecoTotal(sabores);
            ValidarPrecoTotal();

            if (this.IsValid)
            {
                Sabores = sabores;                
                PedidoId = pedidoId;
            }            
        }

        private void ValidarSabores(IList<Sabor> sabores)
        {
            if (sabores == null || (sabores != null && !sabores.Any()))
            {
                AddNotification("saboresPizza", "Por favor passe pelo menos um sabor para a pizza");
            }
            else  if (sabores != null && sabores.Count > 2)
            {
                AddNotification("saboresQtdePizza", "Por favor passe no máximo dois sabores para a pizza");
            }
            else if (sabores != null && sabores.Any(x => x.EmFalta))
            {
                string saboresEmFalta = String.Join(", ", Sabores.Where(x => x.EmFalta).Select(x => x.Descricao).ToArray());                
                AddNotification("saboresEmFaltaPizza", $"Não é possível criar essa pizza já que existe(m) sabor(es) em falta: {saboresEmFalta}");
            }
        }
        public void CalcularPrecoTotal(IList<Sabor> sabores)
        {
            if (sabores == null || (sabores != null && !sabores.Any()))
            {
                PrecoTotal = Queryable.Average(sabores.Select(x => x.Preco).AsQueryable());
            }
        }

        private void ValidarPrecoTotal()
        {
            if (PrecoTotal <= 0)
            {
                AddNotification("precoTotalPizza", "Foi encontrado um erro ao calcular o preço total dessa pizza, ele tem que ser maior que zero");
            }
        }       
    }
}
