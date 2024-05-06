using System.Net.Mail;
using System.Security.Claims;
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
                if (IsValidEmail(userName))
                {
                    var user = await _userManager.FindByEmailAsync(userName);
                    if (user != null);
                        userName = user.UserName;
                }

                var result = await _signInManager.PasswordSignInAsync(
                    userName,login.Senha, login.Lembrar, lockoutOnFailure: true
                );

                if (result.Succeeded)
                {
                    _logger.LogInformation($"Usario {login.Email} acessou o sistema!");
                    return LocalRedirect(login.UrlRetorno);
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning($"Usario {login.Email} está bloqueado!");
                    ModelState.AddModelError(string.Empty, "Conta bloqueado! Aguarde alguns minutos para continuar!");
                }

                ModelState.AddModelError(string.Empty, "Usuario e/ou Senha invalidos!!!");
            }
            return View(login);
        }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Logout(){
                _logger.LogInformation($"Usario {ClaimTypes.Email} saiu do sistema!");
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }

            public IActionResult AccessDenied(){
                return View();
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
