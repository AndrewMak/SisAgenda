namespace ExemploAgenda.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        IdEndereco = c.Int(nullable: false, identity: true),
                        Logradouro = c.String(),
                        Numero = c.String(),
                        Cep = c.String(),
                        Cidade = c.String(),
                        Estado = c.String(),
                        IdPessoa_IdPessoa = c.Int(),
                    })
                .PrimaryKey(t => t.IdEndereco)
                .ForeignKey("dbo.Pessoa", t => t.IdPessoa_IdPessoa)
                .Index(t => t.IdPessoa_IdPessoa);
            
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        IdPessoa = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        SobreNome = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdPessoa);
            
            CreateTable(
                "dbo.Telefone",
                c => new
                    {
                        IdTelefone = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                        Numero = c.String(),
                        IdPessoa_IdPessoa = c.Int(),
                    })
                .PrimaryKey(t => t.IdTelefone)
                .ForeignKey("dbo.Pessoa", t => t.IdPessoa_IdPessoa)
                .Index(t => t.IdPessoa_IdPessoa);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telefone", "IdPessoa_IdPessoa", "dbo.Pessoa");
            DropForeignKey("dbo.Endereco", "IdPessoa_IdPessoa", "dbo.Pessoa");
            DropIndex("dbo.Telefone", new[] { "IdPessoa_IdPessoa" });
            DropIndex("dbo.Endereco", new[] { "IdPessoa_IdPessoa" });
            DropTable("dbo.Telefone");
            DropTable("dbo.Pessoa");
            DropTable("dbo.Endereco");
        }
    }
}
