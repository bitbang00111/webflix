namespace DevOpsDemo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Birthdate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(maxLength: 250),
                        ImgUrl = c.String(maxLength: 500),
                        Year = c.Int(nullable: false),
                        TrailerUrl = c.String(maxLength: 500),
                        DirectorID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Director", t => t.DirectorID)
                .Index(t => t.DirectorID);
            
            CreateTable(
                "dbo.Director",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Birthdate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Star = c.Int(nullable: false),
                        ChangeDate = c.DateTime(),
                        MovieID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Movie", t => t.MovieID)
                .Index(t => t.MovieID);
            
            CreateTable(
                "dbo.MovieActor",
                c => new
                    {
                        ActorID = c.Int(nullable: false),
                        MovieID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ActorID, t.MovieID })
                .ForeignKey("dbo.Actor", t => t.ActorID, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.MovieID, cascadeDelete: true)
                .Index(t => t.ActorID)
                .Index(t => t.MovieID);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieActor", "MovieID", "dbo.Movie");
            DropForeignKey("dbo.MovieActor", "ActorID", "dbo.Actor");
            DropForeignKey("dbo.Rating", "MovieID", "dbo.Movie");
            DropForeignKey("dbo.Movie", "DirectorID", "dbo.Director");
            DropIndex("dbo.MovieActor", new[] { "MovieID" });
            DropIndex("dbo.MovieActor", new[] { "ActorID" });
            DropIndex("dbo.Rating", new[] { "MovieID" });
            DropIndex("dbo.Movie", new[] { "DirectorID" });
            DropTable("dbo.MovieActor");
            DropTable("dbo.Rating");
            DropTable("dbo.Director");
            DropTable("dbo.Movie");
            DropTable("dbo.Actor");
        }
    }
}
