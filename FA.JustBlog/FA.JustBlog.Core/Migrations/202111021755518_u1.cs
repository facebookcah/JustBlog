namespace FA.JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class u1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Status", c => c.Byte(nullable: false));
            AlterColumn("dbo.Posts", "Status", c => c.Byte(nullable: false));
            AlterColumn("dbo.Comments", "Status", c => c.Byte(nullable: false));
            AlterColumn("dbo.Tags", "Status", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tags", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "Status", c => c.Int(nullable: false));
        }
    }
}
