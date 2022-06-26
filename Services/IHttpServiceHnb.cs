using Models;

namespace Services
{
    public interface IHttpServiceHnb
    {
        Task<TecajeviDTO> GetDataFromHnb(string url, string[] currencies);
    }
}