using Models;

namespace Services
{
    public interface IDbService
    {
        Task<Boolean> SaveTecajeviRazmjene(TecajeviDTO tecajeviForSave);

        Task<List<TecajRazmjene>> GetTecajeviRazmjeneByDate(DateTime startDate, DateTime endDate);
    }
}