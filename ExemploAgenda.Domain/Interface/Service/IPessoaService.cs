using ExemploAgenda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploAgenda.Domain.Interface.Service
{
    public interface IPessoaService
    {
        void Adicionar(Pessoa pessoa);
        void Atualizar(Pessoa pessoa);
        Pessoa ObterPorId(int pessoaid);
        Pessoa ObterPorNome(string nome);
        IEnumerable<Pessoa> ObterTodos();

    }
}
