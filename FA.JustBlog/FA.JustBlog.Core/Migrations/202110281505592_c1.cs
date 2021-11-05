namespace FA.JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Categories", "UpdatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Posts", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Posts", "UpdatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Comments", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Comments", "UpdatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Tags", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Tags", "UpdatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tags", "UpdatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tags", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Comments", "UpdatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Comments", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Posts", "UpdatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Posts", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Categories", "UpdatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Categories", "CreatedOn", c => c.DateTime(nullable: false));
        }
    }
}
