namespace DoctorFlow.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Doctor21 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Specialty = c.String(),
                        WorkPlace = c.String(),
                        WorkAddress = c.String(),
                        WorkPhoneNumber = c.String(),
                        ScheduleStart = c.String(),
                        ScheduleEnd = c.String(),
                        MedicalLicenseNumber = c.Int(nullable: false),
                        MyUserData_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.MyUserData_Id)
                .Index(t => t.MyUserData_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "MyUserData_Id", "dbo.Users");
            DropIndex("dbo.Doctors", new[] { "MyUserData_Id" });
            DropTable("dbo.Doctors");
        }
    }
}
