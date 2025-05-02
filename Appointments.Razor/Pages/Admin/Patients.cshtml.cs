using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;
using Appointments.Razor.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Appointments.Razor.Pages.Admin;

[AuthorizeSession]
public class PatientsModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;

    public List<PatientDto> Patients { get; set; } = new();
    public string? ErrorMessage { get; set; }

    public PatientsModel(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task OnGetAsync()
    {
        var token = HttpContext.Session.GetString("jwtToken");
        if (string.IsNullOrEmpty(token))
        {
            ErrorMessage = "Error JWT.";
            return;
        }

        var client = _httpClientFactory.CreateClient("ApiClient");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        try
        {
            var response = await client.GetAsync("/api/Patients");
            if (!response.IsSuccessStatusCode)
            {
                ErrorMessage = $"invalid API: {response.StatusCode}";
                return;
            }

            var json = await response.Content.ReadAsStringAsync();
            Patients = JsonSerializer.Deserialize<List<PatientDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Exception: {ex.Message}";
        }
    }

    public class PatientDto
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
    }
}
