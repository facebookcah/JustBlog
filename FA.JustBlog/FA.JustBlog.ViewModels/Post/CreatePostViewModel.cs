﻿using FA.JustBlog.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Post
{
    public class CreatePostViewModel
    {


        [Required(ErrorMessage = "Title không được để trống")]
        [StringLength(500, ErrorMessage = "Title không vượt quá 500 kí tự")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Short Description không được để trống")]
        [StringLength(500, ErrorMessage = "Short Description không vượt quá 500 kí tự")]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "Post content không được để trống")]
        [StringLength(225, ErrorMessage = "Post content không vượt quá 500 kí tự")]

        public string PostContent { get; set; }
        [Display(Name = "Seo Url")]
        public string UrlSlug { get; set; }
 
        public string Tags { get; set; }

        public int ViewCount { get; set; }
        public int RateCount { get; set; }
        public int TotalRate { get; set; }
        
        public int CategoryId { get; set; }
        
    }
}
