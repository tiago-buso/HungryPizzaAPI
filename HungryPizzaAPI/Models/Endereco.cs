using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HungryPizzaAPI.Models
{
    public class Endereco
    {   
        public int Id { get; set; }
             
        public string Rua { get; set; }
      
        public string CEP { get; set; }
        
        public string Cidade { get; set; }
       
        public string Estado { get; set; }

        public int? ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
