using AutoMapper;
using Context;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services
{
    public class DbService : IDbService
    {
        private readonly DataContext _context;
        private readonly IHttpServiceHnb _httpService;
        private readonly IMapper _mapper;
        public DbService(DataContext context, IMapper mapper, IHttpServiceHnb httpService)
        {
            _context = context;
            _mapper = mapper;
            _httpService = httpService;

        }

        public async Task<Boolean> CheckIfDataExistsForDateRange(DateTime startDate, DateTime endDate, int days)
        {
            var data = await GetTecajeviRazmjeneByDate(startDate, endDate);

            if (data.Count == days * 2)
            {
                return true;
            }

            return false;
        }

        public async Task<List<TecajRazmjene>> GetTecajeviRazmjeneByDate(DateTime startDate, DateTime endDate)
        {
            var tecajevi = await _context.TecajiRazmjene.Where(x => x.DatumPrimjene >= startDate && x.DatumPrimjene <= endDate).ToListAsync();

            return tecajevi;
        }

        public async Task<Boolean> SaveTecajeviRazmjene(TecajeviDTO tecajeviForSave)
        {
            var tecajeviRazmjene = tecajeviForSave.TecajeviRazmjene;

            foreach (var tecaj in tecajeviRazmjene)
            {

                await _context.TecajiRazmjene.AddAsync(_mapper.Map<TecajRazmjeneDTO, TecajRazmjene>(tecaj));
            }

            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }

            return false;
        }

        public async Task UpdateMissingDates(DateTime startDate, DateTime endDate, string[] currencies)
        {
            var data = await GetTecajeviRazmjeneByDate(startDate, endDate);

            var dates = data.Select(x => x.DatumPrimjene).OrderBy(x => x).ToList();


        }
 
    }
}