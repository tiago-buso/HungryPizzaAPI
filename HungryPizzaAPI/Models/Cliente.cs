using Flunt.Notifications;

namespace HungryPizzaAPI.Models
{
    public class Cliente : Notifiable<Notification>
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
            ValidarNome(nome);
            ValidarEndereco(enderecoId);

            if (this.IsValid) 
            {
                Nome = nome;
                EnderecoId = enderecoId;
            }                        
        }


        private void ValidarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                AddNotification("nomeCliente", "Por favor digite um nome válido");
            }

            if (!string.IsNullOrEmpty(nome) && nome.Length > 5000)
            {
                AddNotification("nomeQtdeCharCliente", "Por favor digite um nome válido com menos de 5000 caracteres");
            }            
        }

        private void ValidarEndereco(int enderecoId)
        {
            if (enderecoId <= 0)
            {
                AddNotification("enderecoIdCliente", "É necessário passar um id de endereço válido para o cliente");
            }
        }
    }
}
