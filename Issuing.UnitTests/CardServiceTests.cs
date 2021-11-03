using AutoMapper;
using Issuing.Application.Dto.Card;
using Issuing.Application.DtoMappings;
using Issuing.Application.Interfaces;
using Issuing.Application.Services.Cards;
using Issuing.Application.Validations.Card;
using Issuing.Domain.Entities;
using Issuing.Domain.Interfaces;
using Issuing.Domain.Interfaces.Repos;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Issuing.UnitTests
{
    public class CardServiceTests
    {
        private CardCreateRequestValidator _validator;
        private IMapper _mapper;
        private ICardService _cardService;

        [SetUp]
        public void Setup()
        {
            var card = new Card { Id = 1, Status = 0, Bin = "abcd", CardNo = "123456", IsExpired = true };

            var cardRepository = new Mock<ICardRepository>();
            cardRepository.Setup(m => m.GetByIdAsync(1)).Returns(Task.FromResult(card)).Verifiable();

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(uof => uof.Cards).Returns(cardRepository.Object);

            _validator = new CardCreateRequestValidator();

            var cardProfile = new CardMappingProfiles();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(cardProfile));
            _mapper = new Mapper(configuration);

            _cardService = new CardService(unitOfWork.Object, _validator, _mapper);
        }

        [Test]
        public void Create_WhenBinNumberLengthSmallerThanThree_ThrowArgumentException()
        {
            var request = new CardCreateRequest
            {
                Bin = "abc"
            };

            Assert.That(() => _cardService.Create(request), Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void UpdateCardStatus_WhenCardStatusIsExpired_ThrowInvalidOperationException()
        {
            var request = new CardStatusUpdateRequest
            {
                CardId = 1,
                StatusCode = 1
            };

            Assert.That(() => _cardService.UpdateCardStatus(request), Throws.Exception.TypeOf<InvalidOperationException>());
        }
    }
}