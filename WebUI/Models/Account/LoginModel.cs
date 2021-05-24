using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAppDemo.WebUI.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email adresini giriniz")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Email formatını kontrol ediniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifrenizi giriniz")]
        [MinLength(6, ErrorMessage = "Şifre alanı en az 6 karakterli olmalıdır")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
