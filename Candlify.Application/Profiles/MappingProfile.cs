using Candlify.Domain.Entities;
using AutoMapper;
using Candlify.Application.Features.Candles.Commands.CreateCandle;
using Candlify.Application.Features.Candles.Commands.UpdateCandle;
using Candlify.Application.Models;

namespace Candlify.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Candle, CandlesListVm>().ReverseMap();
            CreateMap<Candle, CreateCandleCommand>().ReverseMap();
            CreateMap<Candle, UpdateCandleByIdCommand>().ReverseMap();

            CreateMap<CandleVm, Candle>().ReverseMap();
            CreateMap<CandleVm, CreateCandleCommand>().ReverseMap();
            CreateMap<CandleVm, UpdateCandleByIdCommand>().ReverseMap();
        }
    }
}
