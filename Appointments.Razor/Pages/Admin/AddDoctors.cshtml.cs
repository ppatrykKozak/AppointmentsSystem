using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Appointments.Razor.Pages.Admin;

public class AddDoctorModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;

    [BindProperty]
    public string FirstName { get; set; } = "";

    [BindProperty]
    public string LastName { get; set; } = "";

    [BindProperty]
    public string Specialty { get; set; } = "";

    public string? ErrorMessage { get; set; }

    public AddDoctorModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public IActionResult OnGet()
    {
        var role = HttpContext.Session.GetString("userRole");
        if (role != "Admin")
            return RedirectToPage("/Index");

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var token = HttpContext.Session.GetString("jwtToken");
        if (string.IsNullOrEmpty(token))
        {
            ErrorMessage = "Error token JWT.";
            return Page();
        }

        var client = _httpClientFactory.CreateClient("ApiClient");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var newDoctor = new
        {
            FirstName,
            LastName,
            Specialty
        };

        var json = new StringContent(JsonSerializer.Serialize(newDoctor), Encoding.UTF8, "application/json");

        try
        {
            var response = await client.PostAsync("/api/Doctors", json);
            if (!response.IsSuccessStatusCode)
            {
                ErrorMessage = $"Error API: {response.StatusCode}";
                return Page();
            }

            return RedirectToPage("Doctors");
        }
        catch (Exception ex)
        {
            ErrorMessage = $"exception: {ex.Message}";
            return Page();
        }
    }
}
