using Issuing.Application.Dto.Card;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Issuing.Application.Interfaces
{
    public interface ICardService
    {
        Task<CardCreateResponse> Create(CardCreateRequest cardCreateRequest);
        Task<CardCreateResponse> Get(int id);
        Task<List<CardCreateResponse>> ListAll();
        Task<List<CardCreateResponse>> GetPassiveCards();
        Task UpdateCardStatus(CardStatusUpdateRequest cardStatusUpdateRequest);

    }
}
