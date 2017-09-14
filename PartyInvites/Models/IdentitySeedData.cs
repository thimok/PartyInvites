using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PartyInvites.Models
{
    public static class IdentitySeedData
    {
	    private const string AdminUser = "Admin";
	    private const string AdminPassword = "Welkom1!";

	    public static async void EnsurePopulated(IApplicationBuilder app)
	    {
		    UserManager<IdentityUser> userManager = app.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();

		    IdentityUser user = await userManager.FindByIdAsync(AdminUser);
		    if (user == null)
		    {
			    user = new IdentityUser("Admin");
			    await userManager.CreateAsync(user, AdminPassword);
		    }
	    }
    }
}
