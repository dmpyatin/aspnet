namespace EfRepPatTest.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTranslationsToSpaces : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TranslationsToSpaces",
                c => new
                    {
                        Translation_Id = c.Int(nullable: false),
                        Space_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Translation_Id, t.Space_Id })
                .ForeignKey("dbo.Translation", t => t.Translation_Id, cascadeDelete: true)
                .ForeignKey("dbo.Space", t => t.Space_Id, cascadeDelete: true)
                .Index(t => t.Translation_Id)
                .Index(t => t.Space_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TranslationsToSpaces", new[] { "Space_Id" });
            DropIndex("dbo.TranslationsToSpaces", new[] { "Translation_Id" });
            DropForeignKey("dbo.TranslationsToSpaces", "Space_Id", "dbo.Space");
            DropForeignKey("dbo.TranslationsToSpaces", "Translation_Id", "dbo.Translation");
            DropTable("dbo.TranslationsToSpaces");
        }
    }
}
