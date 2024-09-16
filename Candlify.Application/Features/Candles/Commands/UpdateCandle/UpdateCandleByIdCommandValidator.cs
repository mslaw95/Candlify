using Candlify.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candlify.Application.Features.Candles.Commands.UpdateCandle
{
    public class UpdateCandleByIdCommandValidator : AbstractValidator<UpdateCandleByIdCommand>
    {
        private readonly ICandleRepository _candleRepository;

        public UpdateCandleByIdCommandValidator(ICandleRepository candleRepository)
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

        private async Task<bool> CandleNameUnique(UpdateCandleByIdCommand c, CancellationToken cancellationToken)
        {
            return !(await _candleRepository.IsCandleNameUnique(c.Name));
        }
    }
}
