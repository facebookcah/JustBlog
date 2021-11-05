using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.IRepositories;
using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Responsitories
{
    public class CommentRespository : GenericRepository<Comment>,ICommentRespository
    {
        public CommentRespository(JustBlogContext context) : base(context)
        {
            Console.WriteLine("CommentRepository is created");
        }

        public override void Add(Comment entity)
        {
            entity.DateTime = DateTime.Now;
            base.Add(entity);
        }
    }
}
