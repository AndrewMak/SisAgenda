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
            _context.Entry(pessoa).State = EntityState.Modified;
           _context.SaveChanges();
        }

        public void Desativar(int id)
        {
            var pessoa = ObterPorId(id);
            pessoa.Status = false;
            Atualizar(pessoa);
        }

        public Pessoa ObterPorId(int pessoaid)
        {
            var pessoa = _context.Pessoas.Include(x => x.Telefones).Include(p => p.Enderecos).FirstOrDefault(x => x.IdPessoa == pessoaid);
            if (pessoa.Telefones == null)
                pessoa.Telefones = new List<Telefone>();
            if (pessoa.Enderecos == null)
                pessoa.Enderecos = new List<Endereco>();
            return pessoa;
        }

        public Pessoa ObterPorNome(string nome)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Pessoa> ObterTodos()
        {
            return _context.Pessoas.Include(x => x.Telefones).Include(p => p.Enderecos);
        }
    }
}
