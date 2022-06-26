using Models;

namespace Services
{
    public interface IDbService
    {
        Task<Boolean> SaveTecajeviRazmjene(TecajeviDTO tecajeviForSave);

        Task<List<TecajRazmjene>> GetTecajeviRazmjeneByDate(DateTime startDate, DateTime endDate);

        Task< List<TecajRazmjene>> CheckIfDataExistsForDateRange(DateTime startDate, DateTime endDate, int days);

        Task<List<TecajRazmjene>> UpdateMissingDates(DateTime startDate, DateTime endDate, TecajeviDTO freshData);
    }
}