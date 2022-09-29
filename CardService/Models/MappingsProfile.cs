using AutoMapper;
using CardService.Models.Requests;
using CardStorageService.Data;

namespace CardService.Models
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Cards, CardDto>();

            CreateMap<CreateCardRequest, Cards>();
        }
    }
}
