namespace LojaSapatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pedido : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemPedidoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        Preco = c.Double(nullable: false),
                        Sapatos_SP_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Sapatos", t => t.Sapatos_SP_Id)
                .Index(t => t.Sapatos_SP_Id);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Cliente_Id_Cliente = c.Int(),
                        ItemPedido_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id_Cliente)
                .ForeignKey("dbo.ItemPedidoes", t => t.ItemPedido_id)
                .Index(t => t.Cliente_Id_Cliente)
                .Index(t => t.ItemPedido_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedidoes", "ItemPedido_id", "dbo.ItemPedidoes");
            DropForeignKey("dbo.Pedidoes", "Cliente_Id_Cliente", "dbo.Clientes");
            DropForeignKey("dbo.ItemPedidoes", "Sapatos_SP_Id", "dbo.Sapatos");
            DropIndex("dbo.Pedidoes", new[] { "ItemPedido_id" });
            DropIndex("dbo.Pedidoes", new[] { "Cliente_Id_Cliente" });
            DropIndex("dbo.ItemPedidoes", new[] { "Sapatos_SP_Id" });
            DropTable("dbo.Pedidoes");
            DropTable("dbo.ItemPedidoes");
        }
    }
}
