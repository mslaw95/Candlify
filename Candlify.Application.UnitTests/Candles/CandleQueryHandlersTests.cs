using AutoMapper;
using Candlify.Application.Contracts.Persistence;
using Candlify.Application.Features.Candles.Queries.GetCandleById;
using Candlify.Application.Features.Candles.Queries.GetCandleList;
using Candlify.Application.Models;
using Candlify.Application.Profiles;
using Candlify.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace Candlify.Application.UnitTests.Candles
{
    public class CandleQueryHandlersTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICandleRepository> _mockCandleRepository;

        public CandleQueryHandlersTests()
        {
            _mockCandleRepository = RepositoryMocks.GetCandleRepositoryMock();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetCandlesListTest()
        {
            var handler = new GetCandlesListQueryHandler(_mapper, _mockCandleRepository.Object);
            var result = await handler.Handle(new GetCandlesListQuery(), CancellationToken.None);
            result.ShouldBeOfType<List<CandlesListVm>>();
            result.Count.ShouldBe(4);
        }

        [Fact]
        public async Task GetCandleByIdTest()
        {
            var testId = Guid.Parse("a3f00e4b-96a9-4e48-b75d-3fb307cfe632");
            var handler = new GetCandleByIdQueryHandler(_mapper, _mockCandleRepository.Object);
            var result = await handler.Handle(new GetCandleByIdQuery() { Id = testId }, CancellationToken.None);
            result.ShouldNotBeNull();
            result.ShouldBeOfType<CandleVm>();
        }
    }
}