using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;

[ApiController]
[Route("api/[controller]")]
public class NewsController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public NewsController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    [HttpGet]
    [Route("latest")]
    public async Task<IActionResult> GetLatestNews([FromQuery] string query = "technology", [FromQuery] string language = "en")
    {
        // Replace with your News API endpoint and API key
        string apiKey = "f9be800d366e452f9616d299deb230f4";
        string url = $"https://newsapi.org/v2/everything?q={query}&language={language}&apiKey={apiKey}";

        try
        {
            var response = await _httpClient.GetFromJsonAsync<object>(url);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error fetching news", error = ex.Message });
        }
    }
}
