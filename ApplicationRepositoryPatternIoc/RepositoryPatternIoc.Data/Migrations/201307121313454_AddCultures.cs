namespace EfRepPatTest.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCultures : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.Culture",
               c => new
               {
                   Id = c.Int(nullable: false, identity: true),
                   Name = c.String(nullable: false, maxLength: 256),
               })
               .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Culture");
        }
    }
}
