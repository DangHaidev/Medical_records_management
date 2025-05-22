using Medical_record.Application.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


public class AccountController : Controller
{
    private readonly PatientService _patientService;
    public AccountController(PatientService patientService)
    {
        _patientService = patientService;
    }
    [HttpGet]
    public IActionResult Login(string? ReturnUrl)
    {
        ViewBag.ReturnUrl = ReturnUrl;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password,string? ReturnUrl)
    {
        //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        // Giả lập kiểm tra tài khoản
        string role = null;

        if (username == "admin" && password == "123")
        {
            role = "Admin";
        }
        else if (username == "040204015708" && password == "123")
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
                IsPersistent = false
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            // Redirect tùy theo quyền
            //if (role == "Admin")
            //    return RedirectToAction("index", "Home", new { area = "Admin" });
            //var patientId = await _patientService.FindPatientAsync(username);
            return RedirectToAction("Profile", "Home", new { area = "Client", cccd = username });
            //if (Url.IsLocalUrl(ReturnUrl))
            //{
            //    return Redirect(ReturnUrl);
            //}
            //else
            //{
            //    return Redirect("/");
            //}


        }

        ViewBag.Error = "Sai tài khoản hoặc mật khẩu";
        return View();
    }


    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("index", "Home");
    }
}
