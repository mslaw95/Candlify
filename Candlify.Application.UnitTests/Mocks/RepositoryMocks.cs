using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Candlify.Application.Contracts.Persistence;
using Candlify.Domain.Entities;
using Moq;

namespace Candlify.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<ICandleRepository> GetCandleRepositoryMock()
        {
            var candles = new List<Candle>
            {
                new Candle() { Id = Guid.Parse("a3f00e4b-96a9-4e48-b75d-3fb307cfe632"), Name = "Vanilla Candle" },
                new Candle() { Id = Guid.NewGuid(), Name = "Chocolate Candle" },
                new Candle() { Id = Guid.NewGuid(), Name = "Wild berry Candle" },
                new Candle() { Id = Guid.NewGuid(), Name = "Strawberry Candle" }
            };

            var mockCandleRepository = new Mock<ICandleRepository>();
            mockCandleRepository.Setup(repo => repo.ListAllAsync())
                .ReturnsAsync(candles);
            mockCandleRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Guid id) =>
                {
                    return candles.SingleOrDefault(c => c.Id == id);
                });
            mockCandleRepository.Setup(repo => repo.CreateAsync(It.IsAny<Candle>()))
                .ReturnsAsync((Candle candle) =>
                {
                    candles.Add(candle);
                    return candle;
                });
            mockCandleRepository.Setup(repo => repo.UpdateByIdAsync(It.IsAny<Guid>(), It.IsAny<Candle>()))
                .ReturnsAsync((Guid id, Candle candle) =>
                {
                    var candleToUpdate = candles.SingleOrDefault(c => c.Id == id);
                    candleToUpdate.Name = candle.Name;
                    return candleToUpdate;
                });
            mockCandleRepository.Setup(repo => repo.RemoveByIdAsync(It.IsAny<Guid>()))
                .Callback<Guid>(id =>
                {
                    var candleToRemove = candles.SingleOrDefault(c => c.Id == id);
                    if (candleToRemove != null)
                    {
                        candles.Remove(candleToRemove);
                    }
                });

            return mockCandleRepository;
        }
    }
}
