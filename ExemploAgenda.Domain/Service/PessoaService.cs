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
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _repository;
        public PessoaService(IPessoaRepository repository)
        {
            _repository = repository;
        }
        public void Adicionar(Pessoa pessoa)
        {
            _repository.Adicionar(pessoa);
        }

        public void Atualizar(Pessoa pessoa)
        {
            _repository.Atualizar(pessoa);
        }

        public void Desativar(int id)
        {
            _repository.Desativar(id);
        }

        public Pessoa ObterPorId(int pessoaid)
        {
            return _repository.ObterPorId(pessoaid);
        }

        public Pessoa ObterPorNome(string nome)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Pessoa> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public IEnumerable<Pessoa> ObterTodosAtivo(IEnumerable<Pessoa> pessoas)
        {
            return pessoas.Where(c => Pessoa.PessoaAtiva(c));
        }
    }
}
