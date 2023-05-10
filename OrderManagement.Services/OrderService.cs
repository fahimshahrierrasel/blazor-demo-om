using OrderManagement.DTO.Requests;
using OrderManagement.DTO.Responses;
using OrderManagement.Repository.Contracts;
using OrderManagement.Services.Contracts;
using OrderManagement.Services.Mappers;
using Entities = OrderManagement.DataAccess.Entities;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ICollection<Order>> GetOrders()
        {
            var orders = await _orderRepository.GetAllOrders();
            return orders.Select(o => o.ToDTO()).ToList();

        }

        public async Task<Order> GetOrder(Guid orderId)
        {
            var order = await _orderRepository.GetOrder(orderId);
            return order.ToDTO();
        }

        public async Task CreateOrder(OrderRequest orderRequest)
        {
            var order = orderRequest.ToEntity();
            
            await _orderRepository.CreateOrder(order);
        }

        public async Task UpdateOrder(Guid orderId, OrderRequest orderRequest)
        {
            var newWindows = new List<Entities.Window>();
            var newElements = new List<Entities.SubElement>();

            var order = await _orderRepository.GetOrder(orderId);
            
            order.Name = orderRequest.Name;
            order.State = orderRequest.State;
            order.ModifiedDate = DateTime.UtcNow;
            foreach (var window in orderRequest.Windows)
            {
                // Detect if new window is added
                var updatedWindow = order.Windows.FirstOrDefault(w => window.Id == w.Id);
                if(updatedWindow == null)
                {
                    var newWindow = window.ToEntity();
                    newWindow.Order = order;
                    newWindows.Add(newWindow);
                    continue;
                }
                updatedWindow.Name = window.Name;
                updatedWindow.QuantityOfWindows = window.QuantityOfWindows;
                updatedWindow.TotalSubElements = window.TotalSubElements;
                foreach (var element in window.SubElements)
                {
                    // Detect if new element is added
                    var updatedElement = updatedWindow.SubElements.FirstOrDefault(e => e.Id == element.Id);
                    if(updatedElement == null)
                    {
                        var newElement = element.ToEntity();
                        newElement.Window = updatedWindow;
                        newElements.Add(newElement);
                        continue;
                    }
                    updatedElement.Type = (Entities.ElementType)element.Type;
                    updatedElement.Width = element.Width;
                    updatedElement.Height = element.Height;
                }
                // Detect if any element is removed
                var removedElements = updatedWindow.SubElements
                    .Where(e => !window.SubElements.Any(we => we.Id == e.Id)).ToList();
                updatedWindow.SubElements = updatedWindow.SubElements.Except(removedElements).ToList();
            }
            // Detect if any window is removed
            var removedWindows = order.Windows
                .Where(w => !orderRequest.Windows.Any(ow =>  ow.Id == w.Id)).ToList();
            order.Windows = order.Windows.Except(removedWindows).ToList();
            await _orderRepository.UpdateOrder(order, newWindows, newElements);
        }

        public async Task DeleteOrder(Guid orderId)
        {
            await _orderRepository.DeleteOrder(orderId);
        }
    }
}
