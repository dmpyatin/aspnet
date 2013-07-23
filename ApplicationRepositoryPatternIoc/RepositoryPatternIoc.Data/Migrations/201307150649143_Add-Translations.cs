namespace EfRepPatTest.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTranslations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Translation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CultureId = c.Int(nullable: false),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Culture", t => t.CultureId)
                .Index(t => t.CultureId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Translation", new[] { "CultureId" });
            DropForeignKey("dbo.Translation", "CultureId", "dbo.Culture");
            DropTable("dbo.Translation");
        }
    }
}
