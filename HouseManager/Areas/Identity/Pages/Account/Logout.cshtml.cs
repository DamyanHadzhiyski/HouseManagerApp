// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HouseManager.Areas.Identity.Pages.Account
{
    public class LogoutModel(
        SignInManager<IdentityUser> signInManager, 
        ILogger<LogoutModel> logger) : PageModel
    {
        public async Task<IActionResult> OnPost()
        {
            await signInManager.SignOutAsync();
            logger.LogInformation("User logged out.");

            return RedirectToAction("Index", "Home");
        }
    }
}
