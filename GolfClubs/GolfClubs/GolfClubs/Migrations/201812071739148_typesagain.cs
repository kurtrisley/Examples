namespace GolfClubs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class typesagain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClubTypes", "Club_ID", c => c.Int());
            CreateIndex("dbo.ClubTypes", "Club_ID");
            AddForeignKey("dbo.ClubTypes", "Club_ID", "dbo.Clubs", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClubTypes", "Club_ID", "dbo.Clubs");
            DropIndex("dbo.ClubTypes", new[] { "Club_ID" });
            DropColumn("dbo.ClubTypes", "Club_ID");
        }
    }
}
