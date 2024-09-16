using AutoMapper;
using Candlify.Application.Contracts.Persistence;
using MediatR;

namespace Candlify.Application.Features.Candles.Commands.RemoveCandle
{
    internal class RemoveCandleByIdCommandHandler(ICandleRepository candleRepository) : IRequestHandler<RemoveCandleByIdCommand, RemoveCandleByIdCommandResponse>
    {
        public async Task<RemoveCandleByIdCommandResponse> Handle(RemoveCandleByIdCommand request, CancellationToken cancellationToken)
        {
            var removeCandleCommandResponse = new RemoveCandleByIdCommandResponse();
            
            await candleRepository.RemoveByIdAsync(request.Id);

            return removeCandleCommandResponse;
        }
    }
}
