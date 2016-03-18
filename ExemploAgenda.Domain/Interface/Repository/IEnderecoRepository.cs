using ExemploAgenda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploAgenda.Domain.Interface.Repository
{
    public interface IEnderecoRepository
    {
        void Adicionar(Endereco endereco);
        void Atualizar(Endereco endereco);
        Endereco ObterPorId(int enderecoid);
        Pessoa ObterPorPessoa(int PessoaId);
        IEnumerable<Endereco> ObterEnderecosPorPessoa(int pessoaid);

    }
}
