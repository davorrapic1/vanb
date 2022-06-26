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
        var startDate = endDate.AddDays(daysInMonthCalc);
        var currencies = requestData.Par.Split('_', 2);

        if (currencies.Length != 2)
        {
            return BadRequest("Loše upisane valute");
        }


        var isValidData = await _dbService.CheckIfDataExistsForDateRange(startDate, endDate, daysInMonthCalc);

        if (isValidData is not null)
        {
            // parse valid data to response model

            return Ok(isValidData);
        }

        var newItemsDTO = await _httpService.GetDataFromHnb(startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"), currencies);

        var savedData = await _dbService.SaveTecajeviRazmjene(newItemsDTO);


        if (savedData)
        {
            var data = await _dbService.GetTecajeviRazmjeneByDate(startDate, endDate);

            // parse valid data to response model

            return Ok(data);
        }

        return BadRequest("Podaci nisu spremljeni");


    }
}