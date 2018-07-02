namespace LojaSapatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cliente : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clientes", "Cliente_Id_Cliente", "dbo.Clientes");
            DropForeignKey("dbo.Sapatos", "Sapatos_SP_Id", "dbo.Sapatos");
            DropIndex("dbo.Clientes", new[] { "Cliente_Id_Cliente" });
            DropIndex("dbo.Sapatos", new[] { "Sapatos_SP_Id" });
            DropColumn("dbo.Clientes", "Cliente_Id_Cliente");
            DropColumn("dbo.Sapatos", "Sapatos_SP_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sapatos", "Sapatos_SP_Id", c => c.Int());
            AddColumn("dbo.Clientes", "Cliente_Id_Cliente", c => c.Int());
            CreateIndex("dbo.Sapatos", "Sapatos_SP_Id");
            CreateIndex("dbo.Clientes", "Cliente_Id_Cliente");
            AddForeignKey("dbo.Sapatos", "Sapatos_SP_Id", "dbo.Sapatos", "SP_Id");
            AddForeignKey("dbo.Clientes", "Cliente_Id_Cliente", "dbo.Clientes", "Id_Cliente");
        }
    }
}
