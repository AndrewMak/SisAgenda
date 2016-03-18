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
    public class TelefoneService : ITelefoneService
    {
        private readonly ITelefoneRepository _repository;
        public TelefoneService(ITelefoneRepository repository)
        {
            _repository = repository;
        }
        public void Adicionar(Telefone telefone)
        {
            _repository.Adicionar(telefone);
        }

        public void Atualizar(Telefone telefone)
        {
            _repository.Atualizar(telefone);
        }

        public Telefone ObterPorId(int telefoneid)
        {
            return _repository.ObterPorId(telefoneid);
        }

        public Pessoa ObterPorPessoa(int pessoaId)
        {
            return _repository.ObterPorPessoa(pessoaId);
        }

        public IEnumerable<Telefone> ObterTelefonesPorPessoa(int pessoaid)
        {
            return _repository.ObterTelefonesPorPessoa(pessoaid);
        }
    }
}
