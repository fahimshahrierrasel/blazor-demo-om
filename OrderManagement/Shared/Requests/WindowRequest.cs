using System.ComponentModel.DataAnnotations;

namespace OrderManagement.DTO.Requests
{
    public class WindowRequest
    {
        public Guid Id { get; set; }

        [Required, MinLength(3)]
        public string Name { get; set; }
        [Required, Range(1, 99)]
        public int QuantityOfWindows { get; set; }

        [Required, Range(0, 99)]
        public int TotalSubElements { get; set; }

        [ValidateComplexType]
        public ICollection<SubElementRequest> SubElements { get; set; }

        public WindowRequest()
        {
            Id = Guid.NewGuid();
            SubElements = new List<SubElementRequest>();
        }
    }
}
