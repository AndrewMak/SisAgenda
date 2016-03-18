using ExemploAgenda.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExemploAgenda.Domain.Models;

namespace ExemploAgenda.Infra.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {

        public EnderecoRepository()
        {

        }

        public void Adicionar(Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public Pessoa ObterPorId(int enderecoid)
        {
            throw new NotImplementedException();
        }

        public Pessoa ObterPorPessoa(int PessoaId)
        {
            throw new NotImplementedException();
        }
    }
}
