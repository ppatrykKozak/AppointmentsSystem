using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Appointments.Razor.Pages.Admin;

public class CreateModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CreateModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [BindProperty]
    public string FirstName { get; set; } = "";

    [BindProperty]
    public string LastName { get; set; } = "";

    public string? ErrorMessage { get; set; }
    public string? SuccessMessage { get; set; }

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
            ErrorMessage = "error token JWT.";
            return Page();
        }

        var client = _httpClientFactory.CreateClient("ApiClient");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var patientData = new
        {
            FirstName,
            LastName
        };

        var json = new StringContent(JsonSerializer.Serialize(patientData), Encoding.UTF8, "application/json");

        try
        {
            var response = await client.PostAsync("/api/Patients", json);
            if (!response.IsSuccessStatusCode)
            {
                ErrorMessage = $"Invalid API: {response.StatusCode}";
                return Page();
            }

            SuccessMessage = "Patient addet.";
            FirstName = LastName = "";
            return Page();
        }
        catch (Exception ex)
        {
            ErrorMessage = $"exception: {ex.Message}";
            return Page();
        }
    }
}
