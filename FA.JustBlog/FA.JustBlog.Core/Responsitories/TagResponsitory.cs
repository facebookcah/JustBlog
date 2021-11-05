using FA.JustBlog.Common;
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
    public class TagResponsitory : GenericRepository<Tag>, ITagRepository
    {
        public TagResponsitory(JustBlogContext context) : base(context)
        {
            Console.WriteLine("TagRepository is created");
        }
   
        public List<Tag> AddTagByString(string tags)
        {
            List<Tag> listTag = new List<Tag>();
            var tagNames = tags.Split(';');

            foreach (var tagName in tagNames)
            {
                var tagExisting = this.dbSet.Where(t => t.TagName.Trim().ToLower() == tagName.Trim().ToLower()).Count();
                if (tagExisting == 0)
                {
                    var tag = new Tag()
                    {
                        TagName = tagName,
                        UrlSlug = SeoUrlHelper.FrientlyUrl(tagName),
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now,
                        Status = Enums.Status.Active
                    };
                    this.dbSet.Add(tag);
                    
                }
            }
            this.context.SaveChanges();
            foreach (var tagName in tagNames)
            {
                var tagExisting = this.dbSet.FirstOrDefault(t => t.TagName.Trim().ToLower() == tagName.Trim().ToLower());
                if (tagExisting != null)
                {
                    listTag.Add(tagExisting);
                }
            }
            return listTag;

        }
    }
}
