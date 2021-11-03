using Issuing.Application.Dto.Card;
using Issuing.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Issuing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardsController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost]
        public async Task<ActionResult<CardCreateResponse>> Create(CardCreateRequest cardCreateRequest)
        {
            var result = await _cardService.Create(cardCreateRequest);
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CardCreateResponse>> Get(int id)
        {
            return await _cardService.Get(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<CardCreateResponse>>> ListAll()
        {
            return await _cardService.ListAll(); ;
        }

        [HttpGet("passiveCards")]
        public async Task<ActionResult<List<CardCreateResponse>>> GetPassiveCards()
        {
            return await _cardService.GetPassiveCards();
        }

        [HttpPut("updateStatu")]
        public async Task UpdateCardStatus([FromBody] CardStatusUpdateRequest cardStatusUpdateRequest)
        {
            await _cardService.UpdateCardStatus(cardStatusUpdateRequest);
        }
    }
}
