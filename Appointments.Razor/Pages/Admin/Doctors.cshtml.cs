using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;
using Appointments.Razor.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Appointments.Razor.Pages.Admin;

[AuthorizeSession]
public class DoctorsModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;

    public List<DoctorDto> Doctors { get; set; } = new();
    public string? ErrorMessage { get; set; }

    public DoctorsModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task OnGetAsync()
    {
        var token = HttpContext.Session.GetString("jwtToken");
        if (string.IsNullOrEmpty(token))
        {
            ErrorMessage = "JWT token is missing.";
            return;
        }

        var client = _httpClientFactory.CreateClient("ApiClient");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        try
        {
            var response = await client.GetAsync("/api/Doctors");
            if (!response.IsSuccessStatusCode)
            {
                ErrorMessage = $"Invalid API response: {response.StatusCode}";
                return;
            }

            var json = await response.Content.ReadAsStringAsync();
            Doctors = JsonSerializer.Deserialize<List<DoctorDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Exception: {ex.Message}";
        }
    }

    public class DoctorDto
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Specialty { get; set; } = "";
    }
}
