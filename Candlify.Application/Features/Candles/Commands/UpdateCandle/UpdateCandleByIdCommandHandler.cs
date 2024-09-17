using AutoMapper;
using Candlify.Application.Contracts.Persistence;
using Candlify.Application.Exceptions;
using Candlify.Application.Models;
using Candlify.Domain.Entities;
using MediatR;

namespace Candlify.Application.Features.Candles.Commands.UpdateCandle
{
    public class UpdateCandleByIdCommandHandler(IMapper mapper, ICandleRepository candleRepository) : IRequestHandler<UpdateCandleByIdCommand, UpdateCandleByIdCommandResponse>
    {
        public async Task<UpdateCandleByIdCommandResponse> Handle(UpdateCandleByIdCommand request, CancellationToken cancellationToken)
        {
            var candleToUpdate = await candleRepository.GetByIdAsync(request.Id);
            if (candleToUpdate == null)
            {
                throw new NotFoundException(nameof(Candle), request.Id);
            }

            var updateCandleByIdCommandResponse = new UpdateCandleByIdCommandResponse();

            var validator = new UpdateCandleByIdCommandValidator(candleRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var updateCandle = mapper.Map<Candle>(request);
                updateCandle.UpdatedDateTime = DateTime.Now;
                await candleRepository.UpdateByIdAsync(request.Id, updateCandle);
                updateCandleByIdCommandResponse.CandleVm = mapper.Map<CandleVm>(request);
            }

            return updateCandleByIdCommandResponse;
        }
    }
}
