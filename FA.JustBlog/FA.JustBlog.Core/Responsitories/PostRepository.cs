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
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(JustBlogContext context) : base(context)
        {
            Console.WriteLine("PostRepository is created");
        }

      

        public override void Add(Post entity)
        {
            entity.PostedOn = DateTime.Now;
            //entity.Published = true;
            entity.Modifiled = true;
            base.Add(entity);
        }

        public Post GetBySeoUrl(string seoUrl)
        {
            return this.dbSet.FirstOrDefault(x => x.UrlSlug == seoUrl);
        }
    }
}
