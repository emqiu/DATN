using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TGClothes.Models
{
    public class LoginModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Mời nhập email")]
        [RegularExpression(@"^[a-zA-Z0-9]+@gmail\.com$", ErrorMessage = "Địa chỉ email không hợp lệ, vui lòng nhập lại")]
        public string Email { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        public string Password { get; set; }
    }
}