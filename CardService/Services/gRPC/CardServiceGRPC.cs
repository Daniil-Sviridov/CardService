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
            var responce = new GetByClientIDResponse();

            responce.Cards.AddRange(_cardRepositoryService.GetByClientId(request.ClientId.ToString())
                .Select(card => new Cards 
                    {
                    CardNo = card.CardNo,
                    CVV2 = card.CVV2,
                    ExpDate = card.ExpDate.ToString(),
                    Name = card.Name
                    }).ToList());

            ;
            return Task.FromResult(responce);
        }
    }
}
