using OrderManagement.DTO.Enums;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.DTO.Requests
{
    public class SubElementRequest
    {
        public Guid Id { get; set; }

        public int ElementNo { get; set; }

        public ElementType Type { get; set; }

        [Required, Range(1.0, 1000.0)]
        public float Width { get; set; }

        [Required, Range(1.0, 1000.0)]
        public float Height { get; set; }

        public SubElementRequest()
        {
            Id = Guid.NewGuid();
        }

        public SubElementRequest(int no)
        {
            Id = Guid.NewGuid();
            ElementNo = no;
        }
    }
}