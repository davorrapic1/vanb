using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using vanb.Requests;
using vanb.Response;
using vanb.Routes;

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

    [HttpPost(ApiRoute.PostRoute.FindDiffInPar)]
    public async Task<ActionResult> GetHnbData([FromBody] PostRequest requestData)
    {
        if (requestData.Datum is null || requestData.Par is null)
        {
            return BadRequest("Loše uneseni podaci");
        }


        var endDate = DateTime.Parse(requestData.Datum);
        var daysInMOnth = DateTime.DaysInMonth(endDate.Year, endDate.Month) * -1;
  

        var periodStart = endDate.AddDays(daysInMOnth).ToString("yyyy-MM-dd");
        var currencies = requestData.Par.Split('_');

        if (currencies.Length != 2)
        {
            return BadRequest("Loše upisane valute");
        }

        string url = $"https://api.hnb.hr/tecajn/v2?datum-primjene-od={periodStart}&datum-primjene-do={requestData.Datum}&valuta={currencies[0]}&valuta={currencies[1]}&format=xml";


        try
        {
            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(responseBody);

            return Ok(xmlDoc.InnerXml);
        }
        catch (System.Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}