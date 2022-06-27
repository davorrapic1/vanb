using Microsoft.AspNetCore.Mvc;
using Models;
using Requests;
using Response;
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
            var parsedData = parseDate(isValidData);
            return Ok(parsedData);
        }

        var newItemsDTO = await _httpService.GetDataFromHnb(startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"), currencies);
        var savedData = await _dbService.SaveTecajeviRazmjene(newItemsDTO);


        if (savedData)
        {
            var data = await _dbService.GetTecajeviRazmjeneByDate(startDate, endDate);    
            var parsedData = parseDate(data);
            return Ok(parsedData);
        }
        return BadRequest("Podaci nisu spremljeni");
    }

    private List<HttpResponseObject> parseDate(List<TecajRazmjene> data)
    {

        // ovo treba optiomizirati

        var lists = new List<List<TecajRazmjene>>();
    
        for (int i = 0; i < data.Count; i++)
        {
            for (int j = 0; j < data.Count; j++)
            {
                if (data[i].DatumPrimjene == data[j].DatumPrimjene)
                {
                    lists.Add(new List<TecajRazmjene> { data[i], data[j] });
                }
            }
        }

        var httpResponseObject = new List<HttpResponseObject>();

        // srediti matematiku
        foreach (var list in lists)
        {
            var httpResponseObjectItem = new HttpResponseObject();
            httpResponseObjectItem.Datum = list[0].DatumPrimjene.ToString("yyyy-MM-dd");
            httpResponseObjectItem.Odnos = (Decimal.Parse(list[1].SrednjiTecaj) / Decimal.Parse(list[0].SrednjiTecaj)).ToString("N5");
            httpResponseObject.Add(httpResponseObjectItem);
        }

        return httpResponseObject;
    }
}