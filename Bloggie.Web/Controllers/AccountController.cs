using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
                                                                         
        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]//metoda POST per krijimin e nje perdoruesi te ri
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)//create a new user
        {
            if (ModelState.IsValid)
            {
                var identityUser = new IdentityUser
                {
                    UserName = registerViewModel.Username,
                    Email = registerViewModel.Email
                };

                var identityResult = await userManager.CreateAsync(identityUser, registerViewModel.Password);
                if (identityResult.Succeeded)
                {
                    // assign this user the "User" role
                    var roleIdentityResult = await userManager.AddToRoleAsync(identityUser, "User");//(identityResult.Succeeded),ath roli "User" i atribuohet perdoruesit tsapokrijuar

                    if (roleIdentityResult.Succeeded)
                    {
                     
                        return RedirectToAction("Register");
                    }
                }
            }

            
            return View();
        }


        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            var model = new LoginViewModel
            {
                ReturnUrl = ReturnUrl
            };

            return View(model);
        }

        
        [HttpPost]//metoda POST per autentifikimin
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View();

            var signInResult = await signInManager.PasswordSignInAsync(
                loginViewModel.Username,
                loginViewModel.Password,
                isPersistent: false,
                lockoutOnFailure: false);

            if (signInResult.Succeeded)
                return !string.IsNullOrWhiteSpace(loginViewModel.ReturnUrl)
                    ? Redirect(loginViewModel.ReturnUrl)
                    : RedirectToAction("Index", "Home");

            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
        }

        [HttpGet]//metoda per daljen nga llogaria (Logout):
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        
        [HttpGet]//metoda per akses te ndaluar (AccessDenied):
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
