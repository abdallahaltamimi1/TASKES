using Microsoft.EntityFrameworkCore;

namespace TASK5._2.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Precision(10, 2)]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public Categories Category { get; set; }
        public int SupplierId { get; set; }
        public Suppliers Supplier { get; set; }
        public ICollection<PurchaseOrderItems> PurchaseOrderItems
        { get; set; } = new List<PurchaseOrderItems>();
    }
}
