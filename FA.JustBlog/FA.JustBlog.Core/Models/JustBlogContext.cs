using FA.JustBlog.Core.EntityBase;
using FA.JustBlog.Core.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class JustBlogContext : DbContext
    {
        public JustBlogContext() : base("name=connectionString")
        {
            //Database.SetInitializer<JustBlogContext>(new CreateDatabaseIfNotExists<JustBlogContext>());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>()
                        .HasOptional(e => e.Category)
                        .WithMany(d => d.Posts)
                        .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<Tag>()
                .HasMany<Post>(s => s.Posts)
                .WithMany(t => t.Tags)
                .Map(cs =>
                {
                    cs.MapLeftKey("TagId");
                    cs.MapRightKey("PostId");
                    cs.ToTable("PostTagMap");
                });
            modelBuilder.Entity<Comment>()
                       .HasOptional(e => e.Post)
                       .WithMany(d => d.Comments)
                       .HasForeignKey(e => e.PostId);

         

    }
        public override int SaveChanges()
        {
            BeforeSaveChange();
            return base.SaveChanges();
        }

        private void BeforeSaveChange()
        {
            var entities = ChangeTracker.Entries();
            var now = DateTime.Now;
            foreach (var entity in entities)
            {
                if (entity.Entity is IBaseEntity baseEntity)
                {
                    switch (entity.State)
                    {
                        case EntityState.Added:
                            baseEntity.Status = Status.Active;
                            baseEntity.CreatedOn = now;
                            baseEntity.UpdatedOn = now;
                            break;
                        case EntityState.Modified:
                            baseEntity.UpdatedOn = now;
                            break;
                    }
                }
            }
        }
    }
}
