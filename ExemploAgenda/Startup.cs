using ExemploAgenda.Domain.Models;
using Microsoft.Owin;
using Owin;
using System.Collections.Generic;

[assembly: OwinStartupAttribute(typeof(ExemploAgenda.Startup))]
namespace ExemploAgenda
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Pessoa), new List<string> { "IdPessoa" });
            //Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Telefone), new List<string> { "IdTelefone" });
            //Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Endereco), new List<string> { "IdEndereco" });
        }
    }
}
