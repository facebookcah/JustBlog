using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
    public class JustBlogInitializer : CreateDatabaseIfNotExists<JustBlogContext>
    {
        public void SeedData(JustBlogContext context)
        {
            base.Seed(context);
            if (context.Categories.Any()||context.Posts.Any()||context.Tags.Any()||context.Comments.Any())
            {
                return;
            }

            var category = new Category()
            {
                Name = "Category 1",
                UrlSlug = "http/asp.net",
                Description = "nothing",
                //Posts = new List<Post>()
                //{
                //    new Post()
                //    {
                //        Title="Post 1",
                //        ShortDescription="nothing",
                //        PostContent="Ok",
                //        UrlSlug="http/a.bet",
                //        Published=true,
                //        PostedOn=new DateTime(2021,10,10),
                //        Modifiled=true,
                //        RateCount=12,
                //        TotalRate=20,
                //        ViewCount=10,


                //        Tags=new HashSet<Tag>()
                //        {
                //            new Tag()
                //            {
                //                TagName="A",
                //                UrlSlug="http//b.com",
                //                Description="nothing",
                //                Count=10,
                                
                //            },
                //            new Tag()
                //            {
                //                TagName="B",
                //                UrlSlug="http//b.com",
                //                Description="nothing",
                //                Count=10,
                //                Posts=new HashSet<Post>()
                //                {
                //                    new Post()
                //    {
                //        Title="Post 2",
                //        ShortDescription="nothing",
                //        PostContent="Ok",
                //        UrlSlug="http/a.bet",
                //        Published=true,
                //        PostedOn=new DateTime(2021,10,10),
                //        Modifiled=true,
                //        RateCount=12,
                //        TotalRate=20,
                //        ViewCount=10 }
                //                }

                //            }
                            

                //        },
                //        Comments=new HashSet<Comment>()
                //        {
                //            new Comment()
                //            {
                //                CommentHeader="cmt 01",
                //                CommentText="abcxyz",
                //                Email="abc@123.com",
                //                Name="A",
                //                DateTime=DateTime.Now
                //            }
                //        }

                //    }
            //}
            };
           // context.Categories.Add(category);

            //context.SaveChanges();
        }

    }
}
