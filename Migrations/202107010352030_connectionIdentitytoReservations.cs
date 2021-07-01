namespace Sang5_01_07.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class connectionIdentitytoReservations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Customer_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Reservations", "Customer_Id");
            AddForeignKey("dbo.Reservations", "Customer_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "Customer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Reservations", new[] { "Customer_Id" });
            DropColumn("dbo.Reservations", "Customer_Id");
        }
    }
}
