using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab2.Models;
using lab2.Models.ViewModel;

namespace lab2.Controllers
{
				[Authorize]
				public class AccountController : Controller
				{

								private UserManager<IdentityUser> userManager;
								private SignInManager<IdentityUser> signInManager;


								public AccountController(UserManager<IdentityUser> usrMgr, SignInManager<IdentityUser> signInMgr) 
								{
												userManager = usrMgr;
												signInManager = signInMgr;

												IdentidySeedData.EnsurePopulated(usrMgr).Wait();
								}

								[AllowAnonymous]
								public ViewResult Login(string returnUrl)
								{
												return View(new LoginModel
												{
																ReturnUrl = returnUrl
												});
								}

								[HttpPost]
								[AllowAnonymous]
								[ValidateAntiForgeryToken]
								public async Task<IActionResult> Login(LoginModel loginModel)
								{
												if (ModelState.IsValid)
												{
																IdentityUser user = await userManager.FindByNameAsync(userName: loginModel.Name);
																if(user != null)
																{
																				await signInManager.SignOutAsync();
																				if((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
																				{
																								return Redirect(loginModel?.ReturnUrl ?? "/Admin/Index");
																				}
																}
												}
												ModelState.AddModelError("", "Błędna nazwa użytkownika lub hasło");
												return View(loginModel);
								}

								public async Task<RedirectResult> Logout(string returnUrl = "/")
								{
												await signInManager.SignOutAsync();
												return Redirect(returnUrl);
								}
				}
}
