using AutoMapper;
using Candlify.Application.Contracts.Persistence;
using Candlify.Application.Exceptions;
using Candlify.Application.Models;
using Candlify.Domain.Entities;
using MediatR;

namespace Candlify.Application.Features.Candles.Commands.CreateCandle
{
    public class CreateCandleCommandHandler(IMapper mapper, ICandleRepository candleRepository) : IRequestHandler<CreateCandleCommand, CreateCandleCommandResponse>
    {
        public async Task<CreateCandleCommandResponse> Handle(CreateCandleCommand request, CancellationToken cancellationToken)
        {
            var createCandleCommandResponse = new CreateCandleCommandResponse();

            var validator = new CreateCandleCommandValidator(candleRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var newCandle = mapper.Map<Candle>(request);
                newCandle.CreatedDateTime = DateTime.Now;
                await candleRepository.CreateAsync(newCandle);
                createCandleCommandResponse.CandleVm = mapper.Map<CandleVm>(request);
            }

            return createCandleCommandResponse;
        }
    }
}
