using DataAccess;
using Microsoft.EntityFrameworkCore;
using OrderManagement.DataAccess.Entities;
using OrderManagement.Repository.Contracts;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OMDbContext _dbContext;

        public OrderRepository(OMDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<ICollection<Order>> GetAllOrders()
        {
            return await _dbContext
                .Orders
                .Include(o => o.Windows)
                .ThenInclude(w => w.SubElements)
                .OrderByDescending(o => o.CreatedDate)
                .AsSplitQuery()
                .ToListAsync();
        } 

        public async Task<Order> GetOrder(Guid orderId)
        {
            var result = await _dbContext
                .Orders
                .Include(o => o.Windows)
                .ThenInclude(w => w.SubElements)
                .AsSplitQuery()
                .FirstOrDefaultAsync(o => o.Id == orderId);

            return result ?? throw new Exception("Order Not Found");
        }

        public async Task UpdateOrder(Order updatedOrder, List<Window> newWindows, List<SubElement> newElements)
        {
			_dbContext.Orders.Update(updatedOrder);
			_dbContext.Windows.AddRange(newWindows);
			_dbContext.SubElements.AddRange(newElements);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteOrder(Guid orderId)
        {
            var order = await GetOrder(orderId);
            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
        }
    }
}
