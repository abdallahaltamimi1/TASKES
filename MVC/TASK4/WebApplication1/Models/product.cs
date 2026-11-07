using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class product
    {
        public int Id { get; set; }
        public string Supplier { get; set; }
        public string OfferName { get; set; }
        [Precision(4, 2)]
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        
        [NotMapped]
        public string certificateOffer { get; set; }

        [NotMapped]
        public string hospitalityOffer { get; set; }
        [NotMapped]
        public string giftOffer { get; set; }
    }
}
