using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAppDemo.WebUI.Models.Account
{
    public class ResetPasswordModel
    {
        public string Token { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Parola alanını giriniz")]
        public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Compare("Password",ErrorMessage ="Şifreniz uyuşmuyor")]
        //[Required(ErrorMessage = "Parola (tekrar) alanını  giriniz")]
        //public string RePassword { get; set; }
    }
}
