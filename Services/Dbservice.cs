using AutoMapper;
using Context;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services
{
    public class DbService : IDbService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DbService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
    }
}