using Models;

namespace Services
{
    public interface IDbService
    {
        Task<Boolean> SaveTecajeviRazmjene(TecajeviDTO tecajeviForSave);

        Task<List<TecajRazmjene>> GetTecajeviRazmjeneByDate(DateTime startDate, DateTime endDate);

        Task<Boolean> CheckIfDataExistsForDateRange(DateTime startDate, DateTime endDate, int days);

        Task UpdateMissingDates(DateTime startDate, DateTime endDate, string[] currencies);
    }
}