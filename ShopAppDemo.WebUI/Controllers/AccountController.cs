using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopAppDemo.BusinessLayer.Abstract;
using ShopAppDemo.WebUI.EmailServices;
using ShopAppDemo.WebUI.Identity;
using ShopAppDemo.WebUI.Models;
using ShopAppDemo.WebUI.Models.Account;
using System.Threading.Tasks;

namespace ShopAppDemo.WebUI.Controllers
{
    //Tüm post action metodlarında devreye girer.
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private IEmailSender _emailSender;
        private ICardService _cardService;

        public AccountController(UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager,
                                 IEmailSender emailSender,
                                 ICardService cardService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _cardService = cardService;
        }


        //Actions
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken] => istersek metod bazlı token işlemi yapabiliriz.
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new AppUser()
            {
                UserName = model.UserName,
                FullName = model.FullName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var tokenCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new
                {
                    userId = user.Id,
                    token = tokenCode
                });

                await _emailSender.SendEmailAsync(model.Email, "Hesanınızı onaylayınız", $"Lütfen email hesabınızı onaylamak için linke <a href='http://localhost:59013{callbackUrl}'>tıklayınız<a/> ");
                TempData["emailConfirmInfo"] = "Giriş yapabilmeniz için e-posta onayı gereklidir";
                return RedirectToAction("Login", "Account");
            }
            ModelState.AddModelError("", "Bir hata oluştu!");
            return View(model);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                TempData["message"] = "Geçersiz token";
                return View();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    //create card object
                    _cardService.InitializeCard(user.Id);
                    TempData["message"] = "Hesabınız onaylandı";
                    return View();
                    //return RedirectToAction("Index", "Home");
                }
            }
            TempData["message"] = "Hesabınız onaylanmadı!";
            return View();
        }

        [HttpGet]
        [Route("account/[action]")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new LoginModel());
        }

        //[Route("account/[action]")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Böyle bir email sistemde mevcut değildir!");
                return View(model);
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Lütfen hesabınızı email ile onaylayınız");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }


            ModelState.AddModelError("", "Email veya şifre hatalı!");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            TempData["emailValidate"] = "";
            if (string.IsNullOrEmpty(email))
            {
                TempData["emailValidate"] += "Email adresini giriniz";
                return View();
            }
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                TempData["emailValidate"] += "Böyle bir kullanıcı yoktur";
                return View();
            }
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var callbackUrl = Url.Action("ResetPassword", "Account", new
            {
                token = code,
                userId = user.Id
            });

            await _emailSender.SendEmailAsync(email, "Şifre Yenileme", $"Şifrenizi yenilemek için <a href='http://localhost:59013{callbackUrl}'>tıklayınız<a/>");
            TempData["resetPasswordInfo"] = "Şifrenizi sıfırlamak için e-posta adresine gelen linke tıklayın";
            return RedirectToAction("Login", "Account");


        }

        public IActionResult ResetPassword(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return View();
            }
            var model = new ResetPasswordModel
            {
                Token = token
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByIdAsync(model.Email);
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(model);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}