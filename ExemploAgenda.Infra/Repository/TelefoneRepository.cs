﻿using ExemploAgenda.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExemploAgenda.Domain.Models;

namespace ExemploAgenda.Infra.Repository
{
    public class TelefoneRepository : ITelefoneRepository
    {
        public void Adicionar(Telefone telefone)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Telefone telefone)
        {
            throw new NotImplementedException();
        }

        public Telefone ObterPorId(int telefoneid)
        {
            throw new NotImplementedException();
        }

        public Telefone ObterPorPessoa(int pessoaId)
        {
            throw new NotImplementedException();
        }
    }
}
