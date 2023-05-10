using OrderManagement.DTO.Requests;
using OrderManagement.DTO.Responses;

namespace OrderManagement.Services.Contracts
{
    public interface IOrderService
    {
        Task<ICollection<Order>> GetOrders();
        Task<Order> GetOrder(Guid orderId);
        Task CreateOrder(OrderRequest orderRequest);
		Task UpdateOrder(Guid orderId, OrderRequest orderRequest);
		Task DeleteOrder(Guid orderId);
    }
}
