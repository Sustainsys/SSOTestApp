using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace SSOTestApp.Controllers
{
    public class LoginController : Controller
    {
        [Route("Login/{scheme}")]
        public IActionResult Login(string scheme)
        {
            var props = new AuthenticationProperties
            {
                RedirectUri = "/"
            };

            return Challenge(props, scheme);
        }

        [Route("Logout/{scheme}")]
        public async Task<IActionResult> Logout(string scheme)
        {
            await HttpContext.SignOutAsync(scheme);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}