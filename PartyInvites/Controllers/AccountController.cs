﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models.ViewModels;

namespace PartyInvites.Controllers
{
	[Authorize]
    public class AccountController : Controller
    {
	    private UserManager<IdentityUser> _userManager;
	    private SignInManager<IdentityUser> _signInManager;

	    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
	    {
		    _userManager = userManager;
		    _signInManager = signInManager;
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
			    IdentityUser user = await _userManager.FindByNameAsync(loginModel.Name);
			    if (user != null)
			    {
				    if ((await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
				    {
					    return Redirect(loginModel?.ReturnUrl ?? "/Admin/Index");
				    }
			    }
		    }
			ModelState.AddModelError("", "Invalid name or password");
		    return View(loginModel);
	    }

	    public async Task<RedirectResult> Logout(string returnUrl = "/")
	    {
		    await _signInManager.SignOutAsync();
		    return Redirect(returnUrl);
	    }
    }
}
