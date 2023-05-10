using OrderManagement.DTO.Requests;
using OrderManagement.DTO.Responses;
using Entities = OrderManagement.DataAccess.Entities;

namespace OrderManagement.Services.Mappers
{
    public static class WindowMapper
    {
        public static Window ToDTO(this Entities.Window src)
        {
            return new Window(
                Id: src.Id,
                Name: src.Name,
                QuantityOfWindows: src.QuantityOfWindows,
                TotalSubElements: src.TotalSubElements,
                SubElements: src.SubElements.Select(srcSubElement => srcSubElement.ToDTO()).ToList()
            );
        }

        public static Entities.Window ToEntity(this WindowRequest src)
        {
            return new Entities.Window
            {
                Id = src.Id,
                Name = src.Name,
                QuantityOfWindows = src.QuantityOfWindows,
                TotalSubElements = src.TotalSubElements,
                SubElements = src.SubElements.Select(srcSubElement => srcSubElement.ToEntity()).ToList()
            };
        }
    }
}
