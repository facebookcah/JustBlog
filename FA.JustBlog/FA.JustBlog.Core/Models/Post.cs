using FA.JustBlog.Core.EntityBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class Post : BaseEntity
    {
   
        
        [StringLength(500,ErrorMessage ="Title không vượt quá 500 kí tự")]
        [Required(ErrorMessage = "Title không được để trống")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Short Description không được để trống")]
        [StringLength(500, ErrorMessage = "Short Description không vượt quá 500 kí tự")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Post content không được để trống")]
        [StringLength(225, ErrorMessage = "Post content không vượt quá 500 kí tự")]
        public string PostContent { get; set; }
        [StringLength(225)]

        [Display(Name ="Seo Url")]
        public string UrlSlug { get; set; }
        [Required]
        public bool Published { get; set; }
        [Required]

        public DateTime PostedOn { get; set; }
        [Required]

        public bool Modifiled { get; set; }
        public int ViewCount { get; set; }
        public int RateCount { get; set; }
        public int TotalRate { get; set; }
        public double rate;
        public double Rate
        {
            get => TotalRate / RateCount;
            set
            {
                rate = TotalRate / RateCount ;
            }
        }

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
