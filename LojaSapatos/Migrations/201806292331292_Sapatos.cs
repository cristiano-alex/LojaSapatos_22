namespace LojaSapatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sapatos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id_Cliente = c.Int(nullable: false, identity: true),
                        Cl_Nome = c.String(),
                        Cl_Endereco = c.String(),
                        CL_Numero = c.Int(nullable: false),
                        CL_Cidade = c.String(),
                        CL_Estado = c.String(),
                        CL_Cep = c.String(),
                        CL_Telefone = c.String(),
                        CL_CPF = c.String(),
                        CL_RZ = c.String(),
                        CL_Genero = c.String(),
                        CL_Email = c.String(),
                        CL_DataNasc = c.DateTime(nullable: false),
                        Cliente_Id_Cliente = c.Int(),
                    })
                .PrimaryKey(t => t.Id_Cliente)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id_Cliente)
                .Index(t => t.Cliente_Id_Cliente);
            
            CreateTable(
                "dbo.Sapatos",
                c => new
                    {
                        SP_Id = c.Int(nullable: false, identity: true),
                        SP_Nome = c.String(),
                        SP_Cadarco = c.Boolean(nullable: false),
                        SP_Material = c.String(),
                        SP_Cor = c.String(),
                        SP_Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sapatos_SP_Id = c.Int(),
                    })
                .PrimaryKey(t => t.SP_Id)
                .ForeignKey("dbo.Sapatos", t => t.Sapatos_SP_Id)
                .Index(t => t.Sapatos_SP_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sapatos", "Sapatos_SP_Id", "dbo.Sapatos");
            DropForeignKey("dbo.Clientes", "Cliente_Id_Cliente", "dbo.Clientes");
            DropIndex("dbo.Sapatos", new[] { "Sapatos_SP_Id" });
            DropIndex("dbo.Clientes", new[] { "Cliente_Id_Cliente" });
            DropTable("dbo.Sapatos");
            DropTable("dbo.Clientes");
        }
    }
}
