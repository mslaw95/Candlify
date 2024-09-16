using AutoMapper;
using Candlify.Application.Contracts.Persistence;
using Candlify.Domain.Entities;
using MediatR;

namespace Candlify.Application.Features.Candles.Queries.GetCandleById
{
    public class GetCandleByIdQueryHandler(IMapper mapper, ICandleRepository candleRepository) : IRequestHandler<GetCandleByIdQuery, CandleVm>
    {
        public async Task<CandleVm> Handle(GetCandleByIdQuery request, CancellationToken cancellationToken)
        {
            var candle = await candleRepository.GetByIdAsync(request.Id);
            return mapper.Map<CandleVm>(candle);
        }
    }
}
