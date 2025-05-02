using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Appointments.Razor.Pages.Auth;

public class LoginModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;

    [BindProperty]
    public string Username { get; set; } = "";

    [BindProperty]
    public string Password { get; set; } = "";

    public string? ErrorMessage { get; set; }

    public LoginModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public IActionResult OnGet()
    {
        if (HttpContext.Session.GetString("jwtToken") != null)
        {
            return RedirectToPage("/Index");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var client = _httpClientFactory.CreateClient("ApiClient");

        var loginData = new
        {
            Username = Username,
            Password = Password
        };

        var json = new StringContent(JsonSerializer.Serialize(loginData), Encoding.UTF8, "application/json");

        try
        {
            var response = await client.PostAsync("/api/Auth/login", json);

            if (!response.IsSuccessStatusCode)
            {
                ErrorMessage = "Invalid login or password.";
                return Page();
            }

            var result = await response.Content.ReadAsStringAsync();
            var jsonDoc = JsonDocument.Parse(result);
            var token = jsonDoc.RootElement.GetProperty("token").GetString();
            var role = jsonDoc.RootElement.GetProperty("role").GetString();

            HttpContext.Session.SetString("jwtToken", token!);
            HttpContext.Session.SetString("userRole", role!);

            return RedirectToPage("/Index");
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Invalid: {ex.Message}";
            return Page();
        }
    }

}
