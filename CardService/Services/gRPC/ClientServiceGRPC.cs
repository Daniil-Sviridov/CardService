using AutoMapper;
using CardsServiceProtos;
using CardStorageService.Data;
using Grpc.Core;
using static CardsServiceProtos.ClientService;

namespace CardService.Services.gRPC
{
    public class ClientServiceGRPC : ClientServiceBase
    {
        private readonly IClientRepositoryService _clientRepositoryService;
        private readonly IMapper _mapper;

        public ClientServiceGRPC(IClientRepositoryService clientRepositoryService, IMapper mapper)
        {
            _clientRepositoryService = clientRepositoryService;
            _mapper = mapper;
        }

        public override Task<CreateClientResponse> Create(ClientCreateRequst request, ServerCallContext context)
        {
            var clientID = _clientRepositoryService.Create(_mapper.Map<Client>(request));

            return Task.FromResult(_mapper.Map<CreateClientResponse>(clientID));            
        }
    }
}
