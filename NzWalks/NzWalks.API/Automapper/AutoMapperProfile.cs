
using AutoMapper;
using NzWalks.API.Models.Domain;
using NzWalks.API.Models.DTO;

namespace NzWalks.API.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<AddRegionRequestDTO, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDTO, Region>().ReverseMap();
        }
    }
}
