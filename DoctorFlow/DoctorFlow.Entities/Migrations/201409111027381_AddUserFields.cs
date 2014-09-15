namespace DoctorFlow.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "SocialSecurityNumber", c => c.String());
            AddColumn("dbo.Users", "Phone", c => c.String());
            AddColumn("dbo.Users", "MaritalStatus", c => c.String());
            AddColumn("dbo.Users", "Height", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "BloodType", c => c.String());
            AddColumn("dbo.Users", "Allergy", c => c.String());
            AddColumn("dbo.Users", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Address");
            DropColumn("dbo.Users", "Allergy");
            DropColumn("dbo.Users", "BloodType");
            DropColumn("dbo.Users", "Height");
            DropColumn("dbo.Users", "MaritalStatus");
            DropColumn("dbo.Users", "Phone");
            DropColumn("dbo.Users", "SocialSecurityNumber");
            DropColumn("dbo.Users", "BirthDate");
        }
    }
}
