using OrderManagement.DTO.Requests;
using OrderManagement.DTO.Responses;
using Entities = OrderManagement.DataAccess.Entities;

namespace OrderManagement.Services.Mappers
{
    public static class OrderMapper
    {
        public static Order ToDTO(this Entities.Order src)
        {
            return new Order(
                Id: src.Id,
                Name: src.Name,
                State: src.State,
                CreatedDate: src.CreatedDate,
                ModifiedDate: src.ModifiedDate,
                Windows: src.Windows.Select(srcWindow => srcWindow.ToDTO()).ToList()
            );
        }

        public static Entities.Order ToEntity(this OrderRequest src)
        {
            return new Entities.Order
            {
                Id = src.Id,
                Name = src.Name,
                State = src.State,
                Windows = src.Windows.Select(srcWindow => srcWindow.ToEntity()).ToList()
            };
        }
    }
}
