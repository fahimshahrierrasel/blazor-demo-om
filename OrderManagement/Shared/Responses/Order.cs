namespace OrderManagement.DTO.Responses
{
    public record Order(Guid Id, String Name, string State, DateTime CreatedDate, DateTime ModifiedDate, ICollection<Window> Windows);
}
