using FA.JustBlog.Core.EntityBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class Tag: BaseEntity
    {
       
        [Required(ErrorMessage = "Tag name is required")]
        [StringLength(225)]
        public string TagName { get; set; }
        [StringLength(225)]

        [Display(Name ="Seo Url")]
        public string UrlSlug { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(1024,ErrorMessage ="Mô tả không được để trống")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Số lượng không được để trống !")]
        public int Count { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
