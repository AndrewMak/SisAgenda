using ExemploAgenda.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExemploAgenda.Domain.Models;
using System.Data.Entity;

namespace ExemploAgenda.Infra.Repository
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly Contexto _context;
        public TelefoneRepository(Contexto context)
        {
            _context = new Contexto();
        }
        public void Adicionar(Telefone telefone)
        {
            try
            {
                _context.Telefones.Add(telefone);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Atualizar(Telefone telefone)
        {
            _context.Entry(telefone).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Telefone ObterPorId(int telefoneid)
        {
            var telefone = _context.Telefones.FirstOrDefault(x => x.IdTelefone == telefoneid);
            return telefone;
        }

        public Pessoa ObterPorPessoa(int pessoaId)
        {
            var pessoa = _context.Pessoas.FirstOrDefault(x=> x.IdPessoa == pessoaId);
            return pessoa;
        }

        public IEnumerable<Telefone> ObterTelefonesPorPessoa(int pessoaid)
        {
            return _context.Telefones.Include(x => x.IdPessoa).Where(p => p.IdPessoa.IdPessoa == pessoaid);
        }
    }
}
