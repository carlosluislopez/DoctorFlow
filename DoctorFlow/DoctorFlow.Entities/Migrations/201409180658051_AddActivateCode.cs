namespace DoctorFlow.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActivateCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ActivateCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ActivateCode");
        }
    }
}
