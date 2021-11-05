using FA.JustBlog.Core.EntityBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class Category : BaseEntity
    {
    
        [Display(Name ="Tên danh mục")]
        [Required(ErrorMessage = "Category name is requierd")]
        [StringLength(225)]
        public string Name { get; set; }

        [Display(Name = "Seo Url")]
        [StringLength(225)]
        public string UrlSlug { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(1024,ErrorMessage ="Mô tả không được để trống")]
        public string Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
