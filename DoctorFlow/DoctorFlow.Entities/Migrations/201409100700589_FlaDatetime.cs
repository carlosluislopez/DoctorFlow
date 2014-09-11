namespace DoctorFlow.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FlaDatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "PasswordFlag", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "PasswordFlag", c => c.Boolean(nullable: false));
        }
    }
}
