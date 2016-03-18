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
    public class EnderecoRepository : IEnderecoRepository
    {

        private readonly Contexto _context;
        public EnderecoRepository(Contexto context)
        {
            _context = new Contexto();
        }

        public void Adicionar(Endereco endereco)
        {
            try
            {
                _context.Enderecos.Add(endereco);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Atualizar(Endereco endereco)
        {
            _context.Entry(endereco).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Endereco> ObterEnderecosPorPessoa(int pessoaid)
        {
            return _context.Enderecos.Include(x => x.IdPessoa).Where(p => p.IdPessoa.IdPessoa == pessoaid);
        }

        public Endereco ObterPorId(int enderecoid)
        {
            var endereco = _context.Enderecos.FirstOrDefault(x => x.IdEndereco == enderecoid);
            return endereco;
        }

        public Pessoa ObterPorPessoa(int PessoaId)
        {
            var pessoa = _context.Pessoas.FirstOrDefault(x => x.IdPessoa == PessoaId);
            return pessoa;
        }
    }
}
