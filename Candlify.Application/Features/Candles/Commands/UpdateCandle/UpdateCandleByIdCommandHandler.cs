using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Candlify.Application.Contracts.Persistence;
using Candlify.Application.Features.Candles.Commands.CreateCandle;
using Candlify.Domain.Entities;
using MediatR;

namespace Candlify.Application.Features.Candles.Commands.UpdateCandle
{
    public class UpdateCandleByIdCommandHandler(IMapper mapper, ICandleRepository candleRepository) : IRequestHandler<UpdateCandleByIdCommand, UpdateCandleByIdCommandResponse>
    {
        public async Task<UpdateCandleByIdCommandResponse> Handle(UpdateCandleByIdCommand request, CancellationToken cancellationToken)
        {
            var updateCandleByIdCommandResponse = new UpdateCandleByIdCommandResponse();

            var validator = new UpdateCandleByIdCommandValidator(candleRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
            {
                updateCandleByIdCommandResponse.Success = false;
                updateCandleByIdCommandResponse.ValidationErrors = [];
                foreach (var error in validationResult.Errors)
                {
                    updateCandleByIdCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
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
