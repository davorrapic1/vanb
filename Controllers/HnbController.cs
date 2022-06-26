using Microsoft.AspNetCore.Mvc;
using Requests;
using Routes;
using Services;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class HnbController : ControllerBase
{

    private readonly IHttpServiceHnb _httpService;
    private readonly IDbService _dbService;
    private readonly ILogger<HnbController> _logger;

    public HnbController(ILogger<HnbController> logger, IDbService dbService, IHttpServiceHnb httpService)
    {

        _logger = logger;
        _dbService = dbService;
        _httpService = httpService;
    }

    [HttpPost(ApiRoute.PostRoute.GetDiff)]
    public async Task<ActionResult> GetHnbData([FromBody] PostRequest requestData)
    {
        if (requestData.Datum is null || requestData.Par is null)
        {
            return BadRequest("Loše uneseni podaci");
        }

        var endDate = DateTime.Parse(requestData.Datum);
        var daysInMonthCalc = DateTime.DaysInMonth(endDate.Year, endDate.Month) * -1;

        var periodStart = endDate.AddDays(daysInMonthCalc).ToString("yyyy-MM-dd");
        var currencies = requestData.Par.Split('_', 2);

        var checkDb = await _dbService.GetTecajeviRazmjeneByDate(DateTime.Parse(periodStart), endDate);
        

        if (currencies.Length != 2)
        {
            return BadRequest("Loše upisane valute");
        }

        string url = $"https://api.hnb.hr/tecajn/v2?datum-primjene-od={periodStart}&datum-primjene-do={requestData.Datum}&valuta={currencies[0]}&valuta={currencies[1]}&format=xml";

        var mappedItems = await _httpService.GetDataFromHnb(url, currencies);

        var result = await _dbService.SaveTecajeviRazmjene(mappedItems);

        return Ok(mappedItems);

    }
}