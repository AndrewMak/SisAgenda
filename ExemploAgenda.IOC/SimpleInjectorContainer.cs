using ExemploAgenda.Domain.Interface.Repository;
using ExemploAgenda.Domain.Interface.Service;
using ExemploAgenda.Domain.Service;
using ExemploAgenda.Infra.Repository;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploAgenda.IOC
{
    public class SimpleInjectorContainer
    {
        public static Container RegisterServices()
        {
            var container = new Container();

            //Registrando as Implementações
            container.Register<IPessoaService, PessoaService>();
            container.Register<IPessoaRepository, PessoaRepository>();


            container.Register<ITelefoneService, TelefoneService>();
            container.Register<ITelefoneRepository, TelefoneRepository>();


            container.Register<IEnderecoService, EnderecoService>();
            container.Register<IEnderecoRepository, EnderecoRepository>();

            container.Verify();
            return container;
        }
    }
}
