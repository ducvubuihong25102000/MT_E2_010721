namespace Sang5_01_07.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userAddnameRegist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
