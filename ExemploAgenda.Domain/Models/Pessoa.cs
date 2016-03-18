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
        public Pessoa()
        {

        }
    
        [Key]
        public int IdPessoa { get; set; }

        public string Nome { get; set; }
        public string SobreNome { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }
        public bool Status { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }

        //pessoa tem que estar ativa e a idade maior que 30 anos
        public static bool PessoaAtiva(Pessoa pessoa)
        {
            return pessoa.Status && DateTime.Now.Year - pessoa.DataNascimento.Year >= 30;
        }
    }
}
