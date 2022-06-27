using AutoMapper;
using Helpers;
using Models;

namespace Services
{

    public class HttpServiceHnb : IHttpServiceHnb
    {
        public readonly IMapper _mapper;

        public HttpServiceHnb(IMapper mapper)
        {
            _mapper = mapper;
        }
        static readonly HttpClient client = new HttpClient();
        public async Task<TecajeviDTO> GetDataFromHnb(string startDate, string endDate, string[] currencies)
        {

             string url = $"https://api.hnb.hr/tecajn/v2?datum-primjene-od={startDate}&datum-primjene-do={endDate}&valuta={currencies[0]}&valuta={currencies[1]}&format=xml";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            
            TecajnaListaXML items = responseBody.ParseXml();

            TecajeviDTO mappedItems = new TecajeviDTO
            {
                TecajeviRazmjene = _mapper.Map<List<TecajRazmjeneDTO>>(items.Item)
            };

            return mappedItems;
        }
    }
}