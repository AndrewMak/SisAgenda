using ExemploAgenda.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExemploAgenda.Domain.Models;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace ExemploAgenda.Infra.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly Contexto _context;
        private readonly string _connectionString;
        public PessoaRepository(Contexto context)
        {
            _context = new Contexto();
            _connectionString = _context.Database.Connection.ConnectionString.ToString();

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
                throw new Exception("Erro ao Cadastrar Pessoa", ex);
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
            const string sql = @"SELECT tc.[IdPessoa] as IdPessoa
          ,tc.[Nome] as Nome      
		  ,tc.[SobreNome] as SobreNome
		  ,tc.[DataNascimento] as DataNascimento
		  ,tc.[Status] as Status    
		  ,tp.[Tipo] As Telefones_Tipo
          ,tp.[Numero] AS Telefones_Numero			  
          FROM Pessoa tc
          INNER JOIN Telefone tp ON tc.IdPessoa = tp.IdPessoa_IdPessoa";

           const string sql2 = @"SELECT tc.[IdPessoa] as IdPessoa
          ,tc.[Nome] as Nome      
		  ,tc.[SobreNome] as SobreNome
		  ,tc.[DataNascimento] as DataNascimento
		  ,tc.[Status] as Status    	
		  ,en.IdEndereco AS Enderecos_IdEndereco	  
		  ,en.Logradouro AS Enderecos_Logradouro
		  ,en.Numero AS Enderecos_Numero
          FROM Pessoa tc
          left JOIN Endereco en ON tc.IdPessoa = en.IdPessoa_IdPessoa";

            var users = new List<Pessoa>();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                dynamic ContatoTelefone = db.Query<dynamic>(sql);
                dynamic ContatoEndereco = db.Query<dynamic>(sql2);


                var ListContato = (Slapper.AutoMapper.MapDynamic<Pessoa>(ContatoTelefone) as IEnumerable<Pessoa>).ToList();
                var ListEndereco = (Slapper.AutoMapper.MapDynamic<Pessoa>(ContatoEndereco) as IEnumerable<Pessoa>).ToList();

                //incluimos o endereços dos contatos, não consegui de outra forma, fazer direto esse procedimento.
                foreach (var item in ListContato)
                {
                    item.Enderecos = ListEndereco.Find(x => x.IdPessoa == item.IdPessoa).Enderecos.ToList();
                }
                return ListContato;
            }

        }
    }
}
