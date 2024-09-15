using Candlify.Domain.Entities;

namespace Candlify.Application.Contracts.Persistence
{
    public interface IEventRepository : IBaseRepository<Event>
    {
        Task<bool> IsEventNameAndDateUnique(string name, DateTime date);
    }
}
