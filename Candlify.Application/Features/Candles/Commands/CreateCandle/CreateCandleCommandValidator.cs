using Candlify.Application.Contracts.Persistence;
using FluentValidation;

namespace Candlify.Application.Features.Candles.Commands.CreateCandle
{
    public class CreateCandleCommandValidator : AbstractValidator<CreateCandleCommand>
    {
        private readonly ICandleRepository _candleRepository;

        public CreateCandleCommandValidator(ICandleRepository candleRepository)
        {
            _candleRepository = candleRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p)
                .MustAsync(CandleNameUnique)
                .WithMessage("An event with the same name and date already exists.");
        }

        private async Task<bool> CandleNameUnique(CreateCandleCommand c, CancellationToken cancellationToken)
        {
            return !(await _candleRepository.IsCandleNameUnique(c.Name));
        }
    }
}
