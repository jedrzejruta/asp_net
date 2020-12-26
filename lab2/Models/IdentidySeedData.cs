using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace lab2.Models
{
				public class IdentidySeedData
				{
								private const string login = "Admin";
								private const string password = "Admin123$";

								public static async Task EnsurePopulated(UserManager<IdentityUser> userManager)
								{
												IdentityUser user = await userManager.FindByIdAsync(login);
												if(user == null)
												{
																user = new IdentityUser("Admin");
																await userManager.CreateAsync(user, password);
												}
								}
				}
}
