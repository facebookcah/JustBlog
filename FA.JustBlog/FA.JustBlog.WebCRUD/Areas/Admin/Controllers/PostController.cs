using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Services.Categories;
using FA.JustBlog.Services.Posts;
using FA.JustBlog.ViewModels.Account;
using FA.JustBlog.ViewModels.Post;
using FA.JustBlog.WebCRUD.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.WebCRUD.Areas.Admin.Controllers
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
            var list = this.postService.GetAllForAdmin();
            return View(list);
        }
        public ActionResult Create()
        {
            var categories = this.categoryService.GetAll();
            IDictionary<int,string> categoryIds = new Dictionary<int,string>();
            foreach (var item in categories)
            {
                categoryIds.Add(item.Id, item.Name);
            }
            ViewBag.categories = categoryIds;
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreatePostViewModel post)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }
            var response = this.postService.Create(post);
            if (response.IsSuccessed)
            {
                
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, response.ErrorMessage);
            return View(post);
        }

        public ActionResult Details(int id)
        {

            var post = this.postService.Find(id);
            var category = this.categoryService.Find((int)post.CategoryId);
            ViewBag.categoryName = category.Name;
            return View(post);
        }

        public ActionResult Delete(int id)
        {

            this.postService.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {

           var post= this.postService.GoToEdit(id);
            ViewBag.status = post.Status;
            ViewBag.published = post.Published;
            ViewBag.Modifiled = post.Modifiled;
            ViewBag.postedOn = post.PostedOn;
            ViewBag.viewCount = post.ViewCount;
            ViewBag.rateCount = post.RateCount;
            ViewBag.totalRate = post.TotalRate;
            ViewBag.rate = post.Rate;
            ViewBag.createdOn = post.CreatedOn;

            var categories = this.categoryService.GetAll();
            IDictionary<int, string> categoryIds = new Dictionary<int, string>();
            foreach (var item in categories)
            {
                categoryIds.Add(item.Id, item.Name);
            }
            ViewBag.categories = categoryIds;
            return View(post);
        }
        [HttpPost]
        public ActionResult Edit(Post post)
        {

            this.postService.Edit(post);
            return RedirectToAction("Index");
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            return RedirectToAction("Index");
        }
    }
}