using OrderManagement.DTO.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.DTO.Requests
{
    public class OrderRequest
    {
        public Guid Id { get; set; }

        [Required, MinLength(3)]
        public string Name { get; set; }

        [Required, MinLength(2)]
        public string State { get; set; }

        [ValidateComplexType, MinimumItem(1)]
        public ICollection<WindowRequest> Windows { get; set; }

        public OrderRequest()
        {
            Id = Guid.NewGuid();
            Windows = new List<WindowRequest>();
        }
    }
}
