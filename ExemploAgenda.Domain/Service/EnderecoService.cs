using ExemploAgenda.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExemploAgenda.Domain.Models;
using ExemploAgenda.Domain.Interface.Repository;

namespace ExemploAgenda.Domain.Service
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _repository;
        public EnderecoService(IEnderecoRepository repository)
        {
            _repository = repository;
        }
        public void Adicionar(Endereco endereco)
        {
            _repository.Adicionar(endereco);
        }

        public void Atualizar(Endereco endereco)
        {
            _repository.Atualizar(endereco);
        }

        public Endereco ObterPorId(int enderecoid)
        {
            return _repository.ObterPorId(enderecoid);
        }

        public Pessoa ObterPorPessoa(int PessoaId)
        {
            throw new NotImplementedException();
        }
    }
}
