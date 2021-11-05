﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Post
{
    public class DropListPost
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title không được để trống")]
        [StringLength(500, ErrorMessage = "Title không vượt quá 500 kí tự")]
        public string Title { get; set; }
    }
}
