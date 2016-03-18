﻿using ExemploAgenda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploAgenda.Domain.Interface.Service
{
    public interface IEnderecoService
    {
        void Adicionar(Endereco endereco);
        void Atualizar(Endereco endereco);
        Endereco ObterPorId(int enderecoid);
        Pessoa ObterPorPessoa(int PessoaId);
        IEnumerable<Endereco> ObterEnderecosPorPessoa(int pessoaid);

    }
}
