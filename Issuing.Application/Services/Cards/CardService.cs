using AutoMapper;
using FluentValidation;
using Issuing.Application.Dto.Card;
using Issuing.Application.Interfaces;
using Issuing.Domain.Interfaces;
using Issuing.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Issuing.Application.Services.Cards
{
    public class CardService : ICardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CardCreateRequest> _cardValidator;
        private readonly IMapper _mapper;

        public CardService(IUnitOfWork unitOfWork, IValidator<CardCreateRequest> cardValidator, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _cardValidator = cardValidator;
            _mapper = mapper;
        }

        public async Task<CardCreateResponse> Create(CardCreateRequest cardCreateRequest)
        {
            var results = await _cardValidator.ValidateAsync(cardCreateRequest);
            ValidateCheck(results);

            var card = _mapper.Map<Domain.Entities.Card>(cardCreateRequest);

            try
            {
                await _unitOfWork.Cards.AddAsync(card);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           
            return _mapper.Map<CardCreateResponse>(card);
        }

        private static void ValidateCheck(FluentValidation.Results.ValidationResult results)
        {
            if (!results.IsValid)
            {
                var errors = string.Empty;
                foreach (var failure in results.Errors)
                {
                    errors += "Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage;
                }

                throw new ArgumentException(errors);
            }
        }

        public async Task<CardCreateResponse> Get(int id)
        {
            var card = await _unitOfWork.Cards.GetByIdAsync(id);
            return _mapper.Map<CardCreateResponse>(card); ;
        }

        public async Task<List<CardCreateResponse>> ListAll()
        {
            var cardListResponse = await _unitOfWork.Cards.ListAllAsync();

            return _mapper.Map<IEnumerable<Domain.Entities.Card>, List<CardCreateResponse>>(cardListResponse);

        }

        public async Task<List<CardCreateResponse>> GetPassiveCards()
        {
            var cardListResponse = await _unitOfWork.Cards.GetPassiveCards();
            return _mapper.Map<IEnumerable<Domain.Entities.Card>, List<CardCreateResponse>>(cardListResponse);
        }

       public async Task UpdateCardStatus(CardStatusUpdateRequest cardStatusUpdateRequest)
        {
            var card = await _unitOfWork.Cards.GetByIdAsync(cardStatusUpdateRequest.CardId);
            if(card == null)
            {
                throw new KeyNotFoundException($"{cardStatusUpdateRequest.CardId} kart bulunamadı");
            }

            if(card.IsExpired)
            {
                throw new InvalidOperationException($"{cardStatusUpdateRequest.CardId} geçerlilik süresi sona ermiş");
            }

            card.Status = cardStatusUpdateRequest.StatusCode;
             _unitOfWork.Cards.Update(card);
            await _unitOfWork.CompleteAsync();
        }
    }
}
