using System.ComponentModel.DataAnnotations;

namespace ExemploAgenda.Models
{
    public class Telefone
    {       
        [Key]
        public int IdTelefone { get; set; }
        public string Tipo { get; set; }
        public string Numero { get; set; }
        public virtual Pessoa IdPessoa { get; set; }
    }
}