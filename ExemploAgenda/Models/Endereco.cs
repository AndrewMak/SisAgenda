using System.ComponentModel.DataAnnotations;

namespace ExemploAgenda.Models
{
    public class Endereco
    {
        [Key]
        public int IdEndereco { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public virtual Pessoa IdPessoa { get; set; }

    }
}