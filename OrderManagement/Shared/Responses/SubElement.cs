using OrderManagement.DTO.Enums;

namespace OrderManagement.DTO.Responses
{
    public record SubElement(Guid Id, ElementType Type, int ElementNo, float Width, float Height);
}
