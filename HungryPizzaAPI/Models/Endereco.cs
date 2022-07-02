using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HungryPizzaAPI.Models
{
    public class Endereco
    {      

        public int Id { get; private set; }
             
        public string Rua { get; private set; }
      
        public string CEP { get; private set; }
        
        public string Cidade { get; private set; }
       
        public string Estado { get; private set; }

        public int? ClienteId { get; private set; }
        public virtual Cliente Cliente { get; private set; }

        public ICollection<Pedido> Pedidos { get; private set; }

        public Endereco()
        {
        }

        public Endereco(string rua, string cep, string cidade, string estado)
        {            
            Rua = rua;
            CEP = cep;
            Cidade = cidade;
            Estado = estado;            
        }

        public Endereco(string rua, string cep, string cidade, string estado, int? clientId)
        {
            Rua = rua;
            CEP = cep;
            Cidade = cidade;
            Estado = estado;
            ClienteId = clientId;           
        }
    }
}
