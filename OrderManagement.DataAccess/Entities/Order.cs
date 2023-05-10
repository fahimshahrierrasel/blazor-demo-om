using System.ComponentModel.DataAnnotations;

namespace OrderManagement.DataAccess.Entities
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        public virtual ICollection<Window> Windows { get; set; }
    }
}
