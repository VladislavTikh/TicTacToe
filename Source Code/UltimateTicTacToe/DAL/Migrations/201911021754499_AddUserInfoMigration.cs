namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserInfoMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Score", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Wins", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Loses", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Winrate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Winrate");
            DropColumn("dbo.AspNetUsers", "Loses");
            DropColumn("dbo.AspNetUsers", "Wins");
            DropColumn("dbo.AspNetUsers", "Score");
        }
    }
}
