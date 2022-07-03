using Flunt.Notifications;

namespace HungryPizzaAPI.Models.Dominios
{
    public class Endereco : Notifiable<Notification>
    {      

        public int Id { get; private set; }
             
        public string Rua { get; private set; }
      
        public string CEP { get; private set; }
        
        public string Cidade { get; private set; }
       
        public string Estado { get; private set; }
      
        public virtual Cliente Cliente { get; private set; }

        public ICollection<Pedido> Pedidos { get; private set; }

        public Endereco()
        {
        }

        public Endereco(string rua, string cep, string cidade, string estado)
        {
            ValidarRua(rua);
            ValidarCEP(cep);
            ValidarCidade(cidade);
            ValidarEstado(estado);

            if (this.IsValid)
            {
                Rua = rua;
                CEP = cep;
                Cidade = cidade;
                Estado = estado;
            }                      
        }


        private void ValidarRua(string rua)
        {
            if (string.IsNullOrEmpty(rua))
            {
                AddNotification("ruaEndereco", "Por favor digite uma rua válida");
            }

            if (!string.IsNullOrEmpty(rua) && rua.Length > 5000)
            {
                AddNotification("ruaQtdeCharEndereco", "Por favor digite uma rua válida com menos de 5000 caracteres");
            }
        }

        private void ValidarCEP(string cep)
        {
            if (string.IsNullOrEmpty(cep))
            {
                AddNotification("cepEndereco", "Por favor digite um CEP válido");
            }

            if (!string.IsNullOrEmpty(cep) && cep.Length > 20)
            {
                AddNotification("cepQtdeCharEndereco", "Por favor digite um CEP válido com menos de 20 caracteres");
            }
        }

        private void ValidarCidade(string cidade)
        {
            if (string.IsNullOrEmpty(cidade))
            {
                AddNotification("cidadeEndereco", "Por favor digite uma cidade válida");
            }

            if (!string.IsNullOrEmpty(cidade) && cidade.Length > 1000)
            {
                AddNotification("cidadeQtdeCharEndereco", "Por favor digite uma cidade válida com menos de 1000 caracteres");
            }
        }

        private void ValidarEstado(string estado)
        {
            if (string.IsNullOrEmpty(estado))
            {
                AddNotification("estadoEndereco", "Por favor digite um estado válido");
            }

            if (!string.IsNullOrEmpty(estado) && estado.Length != 2)
            {
                AddNotification("estadoQtdeCharEndereco", "Por favor digite um estado válido com 2 caracteres");
            }
        }

    }
}
