using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Services.Categories;
using FA.JustBlog.Services.Posts;
using FA.JustBlog.WebCRUD.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.WebCRUD.Controllers
{
    public class PostController : Controller
    {

        private readonly IPostService postService;
        private readonly ICategoryService categoryService;

        public PostController(IPostService postService,ICategoryService categoryService)
        {
            this.postService = postService;
            this.categoryService = categoryService;
        }
        public ActionResult Index()
        {
            var postViewModels = this.postService.GetAll();
            return View(postViewModels);
        }

        public ActionResult LastestPost()
        {
            var postViewModels = this.postService.LastestPost();
            return View("_ListPost",postViewModels);
        }
        public ActionResult MostViewedPosts()
        {
            var postViewModels = this.postService.MostViewedPosts();
            return View("_ListPost", postViewModels);
        }

        public ActionResult Details(int id)
        {
            var post = this.postService.GetAll().Where(p => p.Id == id).FirstOrDefault();
            if (post == null) HttpNotFound();
            return View(post);
        }

        public ActionResult EFCategory()
        {
            var catagoryId = this.categoryService.GetId("Entity Framework");
            var posts = this.postService.GetPostFromCategory(catagoryId);
            return View("_ListPost",posts);
        }
        public ActionResult MVC()
        {
            var catagoryId = this.categoryService.GetId("MVC");
            var posts = this.postService.GetPostFromCategory(catagoryId);
            return View("_ListPost", posts);
        }

        //public ActionResult LastestPost()
        //{
        //    var list = unitOfWork.PostRepository.GetAll();

        //    return View("Index",list);
        //}
        //public ActionResult MostViewedPosts()
        //{
        //    var list = unitOfWork.PostRepository.GetAll().OrderByDescending(p => p.ViewCount).Take(5);

        //    return View("_ListPost",list);
        //}
    }
}