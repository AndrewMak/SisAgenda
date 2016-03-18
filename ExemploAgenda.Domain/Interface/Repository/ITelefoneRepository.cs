using ExemploAgenda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploAgenda.Domain.Interface.Repository
{
    public interface ITelefoneRepository
    {
        void Adicionar(Telefone telefone);
        void Atualizar(Telefone telefone);
        Telefone ObterPorId(int telefoneid);
        Pessoa ObterPorPessoa(int pessoaId);
        IEnumerable<Telefone> ObterTelefonesPorPessoa(int pessoaid);

    }
}
