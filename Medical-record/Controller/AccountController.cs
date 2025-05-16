using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        // Giả lập kiểm tra tài khoản
        string role = null;

        if (username == "admin" && password == "123")
        {
            role = "Admin";
        }
        else if (username == "user" && password == "123")
        {
            role = "Client";
        }

        if (role != null)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role)
        };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            // Redirect tùy theo quyền
            //if (role == "Admin")
            //    return RedirectToAction("index", "Home", new { area = "Admin" });
                return RedirectToAction("Profile", "Home", new { area = "Client" });
        }

        ViewBag.Error = "Sai tài khoản hoặc mật khẩu";
        return View();
    }


    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", "Account");
    }
}
