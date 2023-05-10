namespace OrderManagement.DTO.Responses
{
    public record Window(Guid Id, String Name, int QuantityOfWindows, int TotalSubElements, ICollection<SubElement> SubElements);
}
