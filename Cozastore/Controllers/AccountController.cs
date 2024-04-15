using System.Net.Mail;
using CozaStore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Cozastore.Controllers;
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<IdentityUser>_signInManager;

        private readonly UserManager<IdentityUser>_userManager;
        public AccountController(
            ILogger<AccountController> logger,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager
        )
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        
        {
            LoginVM login = new(){
                UrlRetorno = returnUrl ?? Url.Content("~/")
            };
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login){
            if (ModelState.IsValid){
                string userName = login.Email;
                if (IsValidEmail(userName)){
                    
                }
            }
            return View(login);
        }

        private static bool IsValidEmail(string email){
            try{
                MailAddress mail = new(email);
                return true;
            }
            catch{
                return false;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
