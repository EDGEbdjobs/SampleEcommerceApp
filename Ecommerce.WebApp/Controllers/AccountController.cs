using Ecommerce.Models.IdentityModels;
using Ecommerce.WebApp.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApp.Controllers
{
    public class AccountController : Controller
    {
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;
        RoleManager<AppRole> _roleManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,RoleManager<AppRole> role)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = role;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl=null)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByNameAsync(model.UserName);

                if (existingUser != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(existingUser, model.Password, true, false);

                    if (result.Succeeded)
                    {
                        if (returnUrl == null)
                        {
                            return Redirect("/");
                        }
                        return Redirect(returnUrl);
                    }
                }
            }

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                if(model.Password != model.ConfirmPassword)
                {
                    ModelState.AddModelError("ConfirmPassword", "Password did not match!");

                    return View();
                }


                var user = new AppUser()
                {
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.UserName,
                    Address = model.Address
                };


               var result =  await _userManager.CreateAsync(user, model.Password);

                if(result.Succeeded) { 
                
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
           await  _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Role()
        {
            var roles = _roleManager.Roles.ToList();

            var roleCreateModel = new RoleCreateViewModel();

            if (roles.Any())
            {
                var roleTexts = roles.Select(c => c.Name).ToList();
                roleCreateModel.Roles = roleTexts;
            }
            
            return View(roleCreateModel);
        }

        [HttpPost]
        public async Task<IActionResult> Role(RoleCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                if (model.Role != null)
                {
                    var role = new AppRole()
                    {
                        Name = model.Role
                    };
                    var result = await _roleManager.CreateAsync(role);

                    if(result.Succeeded)
                    {
                        return RedirectToAction("Role");
                    }
                }
            }

            
            
            return View(model);
        }

        //public IActionResult AssignRole()
        //{

        //    return View();
        //}


        [Authorize(Roles="Admin")]
        public async Task<IActionResult> AssignRole(AssignRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByNameAsync(model.UserName);
                if (existingUser != null)
                {
                   var result =  await _userManager.AddToRolesAsync(existingUser, model.Roles);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

            }
            return View();
        }


    }
}
