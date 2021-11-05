using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.UI
{
    class Program
    {
        static JustBlogContext context = new JustBlogContext();
        static IUnitOfWork unitOfWork = new UnitOfWork(context);
        static void Main(string[] args)
        {


            do
            {
                Console.WriteLine("=================== START APPLICATION =================");
                Console.WriteLine("1.Insert 1 record.");
                Console.WriteLine("2.Update 1 record.");
                Console.WriteLine("3.Delete 1 record.");
                Console.WriteLine("4.Get all records.");
                Console.Write("Choose number of function : ");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        InsertCategory();
                        break;
                    case 2:
                        UpdateCategory();
                        break;
                    case 3:
                        DeleteCategory();
                        break;
                    case 4:
                        GetAll();
                        break;
                    default:
                        break;
                }
            } while (true);

            Console.ReadLine();
        }

        private static void GetAll()
        {
            unitOfWork.CategoryRepository.GetAll().ToList().ForEach(c => Console.WriteLine($"Name : {c.Name,-20} UrlSlug : {c.UrlSlug,-30} Status : {c.Status,-10}"));
        }

        private static void UpdateCategory()
        {
            Console.WriteLine("Enter Category Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            var result = unitOfWork.CategoryRepository.GetById(id);
            if (result == null)
            {
                Console.WriteLine($"Category has {id} dose not exist !");
            }
            else
            {
                do
                {
                    Console.WriteLine("1.Update Name.");
                    Console.WriteLine("2.Update UrlSlug.");
                    Console.WriteLine("3.Update Description.");
                    Console.WriteLine("4.Insert 1 post.");
                    Console.Write("Choose number of function : ");
                    int option = Convert.ToInt32(Console.ReadLine());
                    context.Entry(result).State = EntityState.Modified;

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Enter name :");
                            string name = Console.ReadLine();
                            result.Name = name;
                            result.UpdatedOn = DateTime.Now;
                            context.SaveChanges();
                            break;
                        case 2:
                            Console.WriteLine("Enter UrlSlug :");
                            string urlSlug = Console.ReadLine();
                            result.UrlSlug = urlSlug;
                            result.UpdatedOn = DateTime.Now;
                            context.SaveChanges();

                            break;
                        case 3:
                            Console.WriteLine("Enter Description :");
                            string description = Console.ReadLine();
                            result.Description = description;
                            result.UpdatedOn = DateTime.Now;
                            context.SaveChanges();

                            break;
                        case 4:
                            Console.WriteLine("Enter Title : ");
                            string title = Console.ReadLine();
                            Console.WriteLine("Enter ShortDescription : ");
                            string shortDescription = Console.ReadLine();
                            Console.WriteLine("Enter PostContent : ");
                            string postContent = Console.ReadLine();
                            Console.WriteLine("Enter ViewCount :");
                            int vc = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter RateCount :");
                            int rc = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter TotalRate :");
                            int tr = Convert.ToInt32(Console.ReadLine());
                            result.Posts.Add(new Post(title, shortDescription, postContent, vc, rc, tr)) ;
                            context.SaveChanges();

                            break;
                        default:
                            break;
                    }

                } while (true);

            }
        }

        private static void DeleteCategory()
        {
            Console.WriteLine("Enter Category Id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            unitOfWork.CategoryRepository.Delete(id, false);
            context.SaveChanges();
        }

        private static void InsertCategory()
        {


            Console.WriteLine("Enter Category Name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter UrlSlug : ");
            string urlSlug = Console.ReadLine();
            Console.WriteLine("Enter Depscription : ");
            string depscription = Console.ReadLine();
            Console.WriteLine("**1 category must have at least 1 post");
            Console.WriteLine("Enter Title : ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter ShortDescription : ");
            string shortDescription = Console.ReadLine();
            Console.WriteLine("Enter PostContent : ");
            string postContent = Console.ReadLine();
            Console.WriteLine("Enter ViewCount :");
            int vc = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter RateCount :");
            int rc = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter TotalRate :");
            int tr = Convert.ToInt32(Console.ReadLine());
            Category category = new Category()
            {
                Name = name,
                UrlSlug = urlSlug,
                Description = depscription,
                Posts = new List<Post>()
                {
                    new Post(title,shortDescription,postContent,vc,rc,tr)
                }

            };
            unitOfWork.CategoryRepository.Add(category);
            context.SaveChanges();
            Console.WriteLine("==End==");
        }
    }
}
