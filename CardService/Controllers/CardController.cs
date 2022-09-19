using CardStorageService.Data;
using CardService.Models;
using CardService.Services;
using Microsoft.AspNetCore.Mvc;
using CardService.Models.Requests;

namespace CardStorageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardsRepositoryService _cardRepositoryService;

        public CardsController(ICardsRepositoryService cardRepositoryService)
        {
            _cardRepositoryService = cardRepositoryService;
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Create([FromBody] CreateCardRequest request)
        {
            try
            {
                var cardId = _cardRepositoryService.Create(new Cards
                {
                    ClientId = request.ClientId,
                    CardNo = request.CardNo,
                    ExpDate = request.ExpDate,
                    CVV2 = request.CVV2
                });
                return Ok(new CreateCardResponse
                {
                    CardId = cardId.ToString()
                });
            }
            catch (Exception e)
            {
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
            try
            {
                var cards = _cardRepositoryService.GetByClientId(clientId);
                return Ok(new GetCardsResponse
                {
                    Cards = cards.Select(card => new CardDto
                    {
                        CardNo = card.CardNo,
                        CVV2 = card.CVV2,
                        Name = card.Name,
                        ExpDate = card.ExpDate.ToString("MM/yy")
                    }).ToList()
                });
            }
            catch (Exception e)
            {
                return Ok(new GetCardsResponse
                {
                    ErrorCode = 1013,
                    ErrorMessage = "Get cards error."
                });
            }
        }

    }
}
