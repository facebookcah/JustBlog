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
    public class CategoryResponsitory : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryResponsitory(JustBlogContext context) : base(context)
        {
            Console.WriteLine("CategoryRepository is created");
        }
       
    }
}
