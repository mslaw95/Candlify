using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Candlify.Application.Contracts.Persistence;
using Candlify.Application.Exceptions;
using Candlify.Application.Features.Candles.Commands.CreateCandle;
using Candlify.Application.Features.Candles.Commands.RemoveCandle;
using Candlify.Application.Features.Candles.Commands.UpdateCandle;
using Candlify.Application.Profiles;
using Candlify.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace Candlify.Application.UnitTests.Candles
{
    [Collection("SequentialTests")]
    public class CandleCommandHandlersTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICandleRepository> _mockCandleRepository;

        private readonly Guid _testGuid = Guid.Parse("a3f00e4b-96a9-4e48-b75d-3fb307cfe632");

        public CandleCommandHandlersTests()
        {
            _mockCandleRepository = RepositoryMocks.GetCandleRepositoryMock();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task HandleCreate_ValidCandle_CandleAddedToRepo()
        {
            var handler = new CreateCandleCommandHandler(_mapper, _mockCandleRepository.Object);
            await handler.Handle(new CreateCandleCommand() { Name = "Test" }, CancellationToken.None);
            var allCandles = await _mockCandleRepository.Object.ListAllAsync();

            allCandles.Count.ShouldBe(5);
        }

        [Fact]
        public async Task HandleCreate_InvalidCandle_ThrowsValidationException()
        {
            var handler = new CreateCandleCommandHandler(_mapper, _mockCandleRepository.Object);
            await Should.ThrowAsync<ValidationException>(
                async () =>
                {
                    await handler.Handle(
                        new CreateCandleCommand()
                            { Name = "" }, CancellationToken.None);
                });
        }

        [Fact]
        public async Task HandleUpdate_ValidCandle_CandleUpdatedInRepo()
        {
            var handler = new UpdateCandleByIdCommandHandler(_mapper, _mockCandleRepository.Object);
            await handler.Handle(
                new UpdateCandleByIdCommand()
                    { Id = _testGuid, Name = "Test" }, CancellationToken.None);
            var updatedCandle = await _mockCandleRepository.Object.GetByIdAsync(_testGuid);

            updatedCandle.ShouldNotBeNull();
            updatedCandle.Name.ShouldBe("Test");
        }

        [Fact]
        public async Task HandleUpdate_InvalidCandleId_ThrowsNotFoundException()
        {
            var handler = new UpdateCandleByIdCommandHandler(_mapper, _mockCandleRepository.Object);
            await Should.ThrowAsync<NotFoundException>(
                async () =>
                {
                    await handler.Handle(
                        new UpdateCandleByIdCommand()
                            { Id = Guid.NewGuid(), Name = "Test" }, CancellationToken.None);
                });
        }

        [Fact]
        public async Task HandleUpdate_InvalidCandle_ThrowsValidationException()
        {
            var handler = new UpdateCandleByIdCommandHandler(_mapper, _mockCandleRepository.Object);
            await Should.ThrowAsync<ValidationException>(
                async () =>
                {
                    await handler.Handle(
                        new UpdateCandleByIdCommand()
                            { Id = _testGuid, Name = "" }, CancellationToken.None);
                });
        }

        [Fact]
        public async Task HandleRemove_ValidId_CandleRemovedInRepo()
        {
            var handler = new RemoveCandleByIdCommandHandler(_mockCandleRepository.Object);
            await handler.Handle(
                new RemoveCandleByIdCommand()
                    { Id = _testGuid }, CancellationToken.None);
            var allCandles = await _mockCandleRepository.Object.ListAllAsync();

            allCandles.Count.ShouldBe(3);
        }
    }
}
