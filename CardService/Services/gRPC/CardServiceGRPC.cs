using AutoMapper;
using CardsServiceProtos;
using Grpc.Core;
using static CardsServiceProtos.CardsService;

namespace CardService.Services.gRPC
{
    public class CardServiceGRPC : CardsServiceBase
    {
        private readonly ICardsRepositoryService _cardRepositoryService;
        private readonly IMapper _mapper;

        public CardServiceGRPC(ICardsRepositoryService cardRepositoryService, IMapper mapper)
        {
            _cardRepositoryService = cardRepositoryService;
            _mapper = mapper;
        }

        public override Task<GetByClientIDResponse> GetByClientID(GetByClientIDRequst request, ServerCallContext context)
        {

            _cardRepositoryService.GetByClientId(request.ClientId.ToString())
            return base.GetByClientID(request, context);
        }
    }
}
