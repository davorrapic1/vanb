using Microsoft.AspNetCore.Mvc;

namespace vanb.Controllers;

[ApiController]
[Route("[controller]")]
public class HnbController : ControllerBase
{
    static readonly HttpClient client = new HttpClient();
    
    private readonly ILogger<HnbController> _logger;

    public HnbController(ILogger<HnbController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetHnbData")]
    public async Task<ActionResult> GetHnbData()
    {
       
        HttpResponseMessage response = await client.GetAsync("https://api.hnb.hr/tecajn/v2?datum-primjene-od=2022-5-3&datum-primjene-do=2022-6-1&valuta=EUR&valuta=USD");

        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();

        
        return  Ok(responseBody);
    }
}
