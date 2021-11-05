namespace FA.JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class u4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Posts", "ShortDescription", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Posts", "PostContent", c => c.String(nullable: false, maxLength: 225));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "PostContent", c => c.String(maxLength: 225));
            AlterColumn("dbo.Posts", "ShortDescription", c => c.String(maxLength: 500));
            AlterColumn("dbo.Posts", "Title", c => c.String(maxLength: 500));
        }
    }
}
