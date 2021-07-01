namespace Sang5_01_07.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cinema_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cinemas",
                c => new
                    {
                        CinemaId = c.String(nullable: false, maxLength: 128),
                        CinemaName = c.String(nullable: false),
                        Description = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.CinemaId);
            
            CreateTable(
                "dbo.Shows",
                c => new
                    {
                        ShowId = c.String(nullable: false, maxLength: 128),
                        CinemaId = c.String(maxLength: 128),
                        ShowDayId = c.String(maxLength: 128),
                        MovieId = c.String(maxLength: 128),
                        ShowTimeId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ShowId)
                .ForeignKey("dbo.Cinemas", t => t.CinemaId)
                .ForeignKey("dbo.Movies", t => t.MovieId)
                .ForeignKey("dbo.ShowDays", t => t.ShowDayId)
                .ForeignKey("dbo.ShowTimes", t => t.ShowTimeId)
                .Index(t => t.CinemaId)
                .Index(t => t.ShowDayId)
                .Index(t => t.MovieId)
                .Index(t => t.ShowTimeId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationId = c.String(nullable: false, maxLength: 128),
                        ShowId = c.String(maxLength: 128),
                        SeatId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ReservationId)
                .ForeignKey("dbo.Seats", t => t.SeatId)
                .ForeignKey("dbo.Shows", t => t.ShowId)
                .Index(t => t.ShowId)
                .Index(t => t.SeatId);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        SeatID = c.String(nullable: false, maxLength: 128),
                        SeatNo = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.SeatID);
            
            CreateTable(
                "dbo.ShowDays",
                c => new
                    {
                        ShowDayID = c.String(nullable: false, maxLength: 128),
                        Day = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShowDayID);
            
            CreateTable(
                "dbo.ShowTimes",
                c => new
                    {
                        ShowTimeID = c.String(nullable: false, maxLength: 128),
                        Time = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ShowTimeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shows", "ShowTimeId", "dbo.ShowTimes");
            DropForeignKey("dbo.Shows", "ShowDayId", "dbo.ShowDays");
            DropForeignKey("dbo.Reservations", "ShowId", "dbo.Shows");
            DropForeignKey("dbo.Reservations", "SeatId", "dbo.Seats");
            DropForeignKey("dbo.Shows", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Shows", "CinemaId", "dbo.Cinemas");
            DropIndex("dbo.Reservations", new[] { "SeatId" });
            DropIndex("dbo.Reservations", new[] { "ShowId" });
            DropIndex("dbo.Shows", new[] { "ShowTimeId" });
            DropIndex("dbo.Shows", new[] { "MovieId" });
            DropIndex("dbo.Shows", new[] { "ShowDayId" });
            DropIndex("dbo.Shows", new[] { "CinemaId" });
            DropTable("dbo.ShowTimes");
            DropTable("dbo.ShowDays");
            DropTable("dbo.Seats");
            DropTable("dbo.Reservations");
            DropTable("dbo.Movies");
            DropTable("dbo.Shows");
            DropTable("dbo.Cinemas");
        }
    }
}
