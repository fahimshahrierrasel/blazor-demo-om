using OrderManagement.DataAccess.Entities;

namespace OrderManagement.Repository.Contracts
{
    public interface IOrderRepository
    {
        Task<ICollection<Order>> GetAllOrders();
        Task<Order> GetOrder(Guid orderId);
        Task UpdateOrder(Order order, List<Window> newWindows, List<SubElement> newElements);
        Task DeleteOrder(Guid orderId);
        Task CreateOrder(Order order);
    }
}
