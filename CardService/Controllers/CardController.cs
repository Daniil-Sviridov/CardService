using CardStorageService.Data;
using CardService.Models;
using CardService.Services;
using Microsoft.AspNetCore.Mvc;
using CardService.Models.Requests;
using CardService.Models.Response;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace CardStorageService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardsRepositoryService _cardRepositoryService;
        private readonly ILogger<CardsController> _logger;
        private readonly IMapper _mapper;

        public CardsController(ICardsRepositoryService cardRepositoryService, ILogger<CardsController> logger, IMapper mapper)
        {
            _cardRepositoryService = cardRepositoryService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Create([FromBody] CreateCardRequest request)
        {
            try
            {
                //var cardId = _cardRepositoryService.Create(new Cards
                //{
                //    ClientId = request.ClientId,
                //    CardNo = request.CardNo,
                //    ExpDate = request.ExpDate,
                //    CVV2 = request.CVV2
                //});

                var cardId = _cardRepositoryService.Create(_mapper.Map<Cards>(request));

                return Ok(new CreateCardResponse
                {
                    CardId = cardId.ToString()
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Create card error");
                return Ok(new CreateCardResponse
                {
                    ErrorCode = 1012,
                    ErrorMessage = "Create card error."
                });
            }
        }

        [HttpGet("get-by-client-id")]
        [ProducesResponseType(typeof(GetCardsResponse), StatusCodes.Status200OK)]
        public IActionResult GetByClientId([FromQuery] string clientId)
        {
            _logger.Log(LogLevel.Information, "Get cards.");

            try
            {
                var cards = _cardRepositoryService.GetByClientId(clientId);
                return Ok(new GetCardsResponse
                {
                    //Cards = cards.Select(card => new CardDto
                    //{
                    //    CardNo = card.CardNo,
                    //    CVV2 = card.CVV2,
                    //    Name = card.Name,
                    //    ExpDate = card.ExpDate.ToString("MM/yy")
                    //}).ToList()

                    Cards = _mapper.Map<List<CardDto>>(cards)

                }) ; 
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Get cards error.");
                return Ok(new GetCardsResponse
                {
                    ErrorCode = 1013,
                    ErrorMessage = "Get cards error."
                });
            }
        }

    }
}
