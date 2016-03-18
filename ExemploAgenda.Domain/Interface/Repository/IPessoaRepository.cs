using ExemploAgenda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploAgenda.Domain.Interface.Repository
{
    public interface IPessoaRepository
    {
        void Adicionar(Pessoa pessoa);
        void Atualizar(Pessoa pessoa);
        Pessoa ObterPorId(int pessoaid);
        Pessoa ObterPorNome(string nome);
         IEnumerable<Pessoa> ObterTodos();
        void Desativar(int id);
    }
}
