using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace TASK5._2.Models
{
    public class PurchaseOrderItems
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [Precision(10, 2)]
        public decimal UnitPrice { get; set; }
        public Products Product { get; set; }
        public PurchaseOrders PurchaseOrder { get; set; }
    }
}
