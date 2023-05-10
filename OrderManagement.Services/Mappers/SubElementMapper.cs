using OrderManagement.DTO.Enums;
using OrderManagement.DTO.Requests;
using OrderManagement.DTO.Responses;
using Entities = OrderManagement.DataAccess.Entities;

namespace OrderManagement.Services.Mappers
{
    public static class SubElementMapper
    {

        public static SubElement ToDTO(this Entities.SubElement src)
        {
            return new SubElement(
                Id: src.Id,
                Type: (ElementType)src.Type,
                ElementNo: src.ElementNo,
                Width: src.Width,
                Height: src.Height
            );
        }

        public static Entities.SubElement ToEntity(this SubElementRequest src)
        {
            return new Entities.SubElement
            {
                Id = src.Id,
				Type = (Entities.ElementType)src.Type,
                ElementNo = src.ElementNo,
                Width = src.Width,
                Height = src.Height
            };
        }
    }
}
