using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploAgenda.Domain.Models
{
    public class Pessoa
    {
        [Key]
        public int IdPessoa { get; set; }

        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Status { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
    }
}
