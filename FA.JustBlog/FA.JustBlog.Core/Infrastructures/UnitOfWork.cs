using FA.JustBlog.Core.IRepositories;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FA.JustBlog.Core.Responsitories;

namespace FA.JustBlog.Core.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JustBlogContext context;
        private ICommentRespository commentRespository;
        private ITagRepository tagRepository;
        private IPostRepository postRepository;
        private ICategoryRepository categoryRepository;
        public UnitOfWork(JustBlogContext context)
        {
            this.context = context;
        }
        public ICommentRespository CommentRespository
        {
            get {
                if (this.commentRespository == null)
                {
                    this.commentRespository = new CommentRespository(this.context);
                }
                return this.commentRespository;
            }
        }
        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new CategoryResponsitory(this.context);
                }
                return this.categoryRepository;
            }
        }
        public IPostRepository PostRepository
        {
            get
            {
                if (this.postRepository == null)
                {
                    this.postRepository = new PostRepository(this.context);
                }
                return this.postRepository;
            }
        }

        public ITagRepository TagRepository

        {
            get
            {
                if (this.tagRepository == null)
                {
                    this.tagRepository = new TagResponsitory(this.context);
                }
                return this.tagRepository;
            }
        }

        public JustBlogContext JustBlogContext => this.context;


        public void Dispose()
        {
            this.context.Dispose();
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return this.context.SaveChangesAsync();

        }
    }
}
