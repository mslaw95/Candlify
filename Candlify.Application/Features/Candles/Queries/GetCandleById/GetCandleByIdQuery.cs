using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Candlify.Application.Models;
using MediatR;

namespace Candlify.Application.Features.Candles.Queries.GetCandleById
{
    public class GetCandleByIdQuery : IRequest<CandleVm>
    {
        public Guid Id { get; set; }
    }
}
