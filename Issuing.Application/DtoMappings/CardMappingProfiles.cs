using AutoMapper;
using Issuing.Application.Dto.Card;
using Issuing.Domain.Entities;

namespace Issuing.Application.DtoMappings
{
    public class CardMappingProfiles : Profile
    {
        public CardMappingProfiles()
        {
            CreateMap<Card, CardCreateRequest>();

            CreateMap<CardCreateRequest, Card>();

            CreateMap<Card, CardCreateResponse>();

        }
    }
}
