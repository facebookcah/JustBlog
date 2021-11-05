using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.ViewModels.Account
{
    public class Login
    {
        [Required(ErrorMessage ="Email không được để trống")]
        [EmailAddress(ErrorMessage ="Email không đúng")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password không được để trống")]
        [MaxLength(10,ErrorMessage = "Password không vượt quá 10 kí tự")]
        [MinLength(8,ErrorMessage = "Password không ít hơn 8 kí tự")]
        public string Password { get; set; }
    }
}
