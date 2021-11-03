using FluentValidation;
using Issuing.Application.Dto.Card;

namespace Issuing.Application.Validations.Card
{
    public class CardCreateRequestValidator : AbstractValidator<CardCreateRequest>
    {
        public CardCreateRequestValidator()
        {
            RuleFor(item => item)
                   .Must(item => item.Bin.Length > 3)
                   .WithMessage("Bin Lenght must be greater than 3 character");
        }
    }
}
