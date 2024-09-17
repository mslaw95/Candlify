using Candlify.Application.Models;
using MediatR;

namespace Candlify.Application.Features.Candles.Queries.GetCandleList
{
    public class GetCandlesListQuery : IRequest<List<CandlesListVm>>
    {
    }
}
