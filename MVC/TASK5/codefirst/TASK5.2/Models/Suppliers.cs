namespace TASK5._2.Models
{
    public class Suppliers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Products> Products { get; set; }
        public List<PurchaseOrders> PurchaseOrders { get; set; }
    }
}
