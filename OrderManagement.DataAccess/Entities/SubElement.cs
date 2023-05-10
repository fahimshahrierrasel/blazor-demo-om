using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.DataAccess.Entities
{
    public class SubElement
    {
        [Key]
        public Guid Id { get; set; }
        public int ElementNo { get; set; }
        public ElementType Type { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        [ForeignKey("WindowId")]
        public Window Window { get; set; }
    }
}