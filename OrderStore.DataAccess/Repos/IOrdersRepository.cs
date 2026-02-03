using OrderStore.Core.Models;

namespace OrderStore.DataAccess.Repos
{
    public interface IOrdersRepository
    {
        Task<Guid> Create(Order order);
        Task<Guid> Delete(Guid id);
        Task<List<Order>> GetAll();
        Task<Guid> Update(Guid id, string description, decimal price, string assignedTo);
    }
}