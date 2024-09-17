using AutoMapper;
using Candlify.Application.Contracts.Persistence;
using Candlify.Application.Models;
using MediatR;

namespace Candlify.Application.Features.Candles.Queries.GetCandleList
{
    public class GetCandlesListQueryHandler(IMapper mapper, ICandleRepository candleRepository)
        : IRequestHandler<GetCandlesListQuery, List<CandlesListVm>>
    {
        public async Task<List<CandlesListVm>> Handle(GetCandlesListQuery request,
            CancellationToken cancellationToken)
        {
            var candles = (await candleRepository.ListAllAsync()).OrderBy(x => x?.Name);
            return mapper.Map<List<CandlesListVm>>(candles);
        }
    }
}
