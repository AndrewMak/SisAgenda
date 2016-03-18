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
    public class PessoaRepository : IPessoaRepository
    {
        private readonly Contexto _context;
        public PessoaRepository(Contexto context)
        {
            _context = new Contexto();
        }
        public void Adicionar(Pessoa pessoa)
        {
            try
            {
                _context.Pessoas.Add(pessoa);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {                
                throw ex;
            }      
        }

        public void Atualizar(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }

        public Pessoa ObterPorId(int pessoaid)
        {
            return _context.Pessoas.FirstOrDefault(x => x.IdPessoa == pessoaid);
        }

        public Pessoa ObterPorNome(string nome)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Pessoa> ObterTodos()
        {
            return  _context.Pessoas.Include(x => x.Telefones).Include(p => p.Enderecos);
        }
    }
}
