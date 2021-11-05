namespace FA.JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class u2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Name", c => c.String(nullable: false, maxLength: 225));
            AlterColumn("dbo.Comments", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "CommentText", c => c.String(nullable: false, maxLength: 225));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "CommentText", c => c.String());
            AlterColumn("dbo.Comments", "Email", c => c.String());
            AlterColumn("dbo.Comments", "Name", c => c.String());
        }
    }
}
