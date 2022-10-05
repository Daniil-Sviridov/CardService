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
            //var re =  _mapper.Map<Client>(request);

            var clientID = _clientRepositoryService.Create(new Client() {FirstName =  request.FirstName, Surname = request.Surname, Patronymic = request.Patronymic});

            return Task.FromResult(_mapper.Map<CreateClientResponse>(clientID));            
        }
    }
}
