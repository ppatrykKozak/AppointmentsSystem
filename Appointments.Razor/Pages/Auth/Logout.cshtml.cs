using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Appointments.Razor.Pages.Auth;

public class LogoutModel : PageModel
{
    public IActionResult OnPost()
    {
        HttpContext.Session.Remove("jwtToken");
        HttpContext.Session.Remove("userRole");
        return RedirectToPage("/Auth/Login");
    }
}
