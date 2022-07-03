using Flunt.Notifications;

namespace HungryPizzaAPI.Models
{
    public class Pedido : Notifiable<Notification>
    {
        public int Id { get; private set; }

        public DateTime Data { get; private set; } = DateTime.Now;

        public ICollection<Pizza> Pizzas { get; private set; }
        public decimal ValorTotal { get; private set; }

        public int? EnderecoId { get; private set; }
        public Endereco Endereco { get; private set; }

        public int? ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }

        public Pedido()
        {
        }

        public Pedido(DateTime data, ICollection<Pizza> pizzas, int? enderecoId, int? clienteId)
        {
            ValidarData(data);
            ValidarPizzas(pizzas);
            CalcularValorTotal(pizzas);
            ValidarValorTotal();
            ValidarPresencaDeEnderecoOuCliente(enderecoId, clienteId);

            if (this.IsValid)
            {
                Data = data;
                Pizzas = pizzas;
                EnderecoId = enderecoId;
                ClienteId = clienteId;
            }
        }

        private void ValidarData(DateTime data)
        {
            if (data == DateTime.MinValue || data == DateTime.MaxValue)
            {
                AddNotification("dataPedido", "Por favor digite uma data válida");
            }
        }

        private void ValidarPizzas(ICollection<Pizza> pizzas)
        {
            if (pizzas == null || (pizzas != null && !pizzas.Any()))
            {
                AddNotification("pizzaPedido", "Por favor passe pelo menos uma pizza para o pedido");
            }
            else if (pizzas != null && pizzas.Count > 10)
            {
                AddNotification("pizzaQtdePedido", "Por favor passe no máximo dez pizzas para o pedido");
            }
        }

        private void CalcularValorTotal(ICollection<Pizza> pizzas)
        {
            if (pizzas == null || (pizzas != null && !pizzas.Any()))
            {
                ValorTotal = Queryable.Average(Pizzas.Select(x => x.PrecoTotal).AsQueryable());
            }
        }

        private void ValidarValorTotal()
        {
            if (ValorTotal <= 0)
            {
                AddNotification("valorTotalPedido", "Foi encontrado um erro ao calcular o valor total desse pedido, ele tem que ser maior que zero");
            }
        }

        private void ValidarPresencaDeEnderecoOuCliente(int? enderecoId, int? clienteId)
        {
            if (!enderecoId.HasValue && !clienteId.HasValue)
            {
                AddNotification("enderecoOuClientePedido", "É necessário passar ou um endereço ou um cliente para o pedido");
            }
        }
    }
}
