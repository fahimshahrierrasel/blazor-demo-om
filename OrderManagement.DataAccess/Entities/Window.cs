using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.DataAccess.Entities
{
    public class Window
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int QuantityOfWindows { get; set; }
        public int TotalSubElements { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        public virtual ICollection<SubElement> SubElements { get; set; }
    }
}
