using Flunt.Notifications;

namespace HungryPizzaAPI.Models.Dominios
{
    public class Sabor : Notifiable<Notification>
    {   
        public int Id { get; private set; }
      
        public string Descricao { get; private set; }
     
        public decimal Preco { get; private set; }
       
        public bool EmFalta { get; private set; } = false;

        public IList<Pizza> Pizzas { get; private set; }

        public Sabor()
        {
        }

        public Sabor(string descricao, decimal preco, bool emFalta)
        {
            ValidarDescricao(descricao);
            ValidarPreco(preco);

            if (this.IsValid)
            {
                Descricao = descricao;
                Preco = preco;
                EmFalta = emFalta;
            }                   
        }

        private void ValidarDescricao(string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
            {
                AddNotification("descricaoSabor", "Por favor digite uma descrição válida");
            }

            if (!string.IsNullOrEmpty(descricao) && descricao.Length > 500)
            {
                AddNotification("descricaoQtdeCharSabor", "Por favor digite uma descrição válida com menos de 500 caracteres");
            }
        }

        private void ValidarPreco(decimal preco)
        {
            if (preco <= 0)
            {
                AddNotification("precoSabor", "Por favor digite um preço válido, maior que zero");
            }          
        }
    }
}
