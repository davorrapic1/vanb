using Models;

namespace Services
{
    public interface IHttpServiceHnb
    {
        Task<TecajeviDTO> GetDataFromHnb(string startDate, string endDate, string[] currencies);
    }
}