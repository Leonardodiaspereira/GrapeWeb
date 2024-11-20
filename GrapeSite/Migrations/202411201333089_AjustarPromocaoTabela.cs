namespace GrapeSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjustarPromocaoTabela : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Promocaos", newName: "promocao");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.promocao", newName: "Promocaos");
        }
    }
}
