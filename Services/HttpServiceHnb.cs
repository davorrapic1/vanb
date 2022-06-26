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
        public async Task<TecajeviDTO> GetDataFromHnb(string url, string[] currencies)
        {
            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            TecajnaListaXML items = responseBody.ParseXml();

            var mappedItems = new TecajeviDTO
            {
                TecajeviRazmjene = _mapper.Map<List<TecajRazmjeneDTO>>(items.Item)
            };

            return mappedItems;
        }
    }
}