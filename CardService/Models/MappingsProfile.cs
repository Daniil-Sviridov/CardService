using AutoMapper;
using CardService.Models.Requests;
using CardsServiceProtos;
using CardStorageService.Data;

namespace CardService.Models
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<CardStorageService.Data.Cards, CardDto>();

            CreateMap<CreateCardRequest, CardStorageService.Data.Cards>();

            CreateMap<Client, ClientDto>();

            CreateMap<Client, ClientCreateRequst>();

            CreateMap<CreateClientResponse, Client>();

        }
    }
}
