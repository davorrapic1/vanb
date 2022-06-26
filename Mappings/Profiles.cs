using AutoMapper;
using Models;

namespace vanb.Mappings
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Item, TecajRazmjeneDTO>()
                .ForMember(dest => dest.DatumPrimjene, opt => opt.MapFrom(src =>  DateTime.Parse(src.DatumPrimjene)));

            CreateMap<TecajRazmjeneDTO, TecajRazmjene>();
        }

    }
}