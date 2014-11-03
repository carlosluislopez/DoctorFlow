namespace DoctorFlow.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveIDRol : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rols", "User_Id", "dbo.Users");
            DropIndex("dbo.Rols", new[] { "User_Id" });
            DropColumn("dbo.Rols", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rols", "User_Id", c => c.Int());
            CreateIndex("dbo.Rols", "User_Id");
            AddForeignKey("dbo.Rols", "User_Id", "dbo.Users", "Id");
        }
    }
}
