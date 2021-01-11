using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAppDemo.WebUI.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Tam adınızı giriniz")]
        public string FullName { get; set; }

        [Required(ErrorMessage ="Kullanıcı adı alanını giriniz")]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email adresini giriniz")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Parola alanını giriniz")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        [Required(ErrorMessage = "Parola (tekrar) alanını  giriniz")]
        public string RePassword { get; set; }
    }
}
