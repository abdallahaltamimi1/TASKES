using System;
using System.Collections.Generic;

namespace University_Cafeteria_2.Models;

public partial class PurchaseOrderItem
{
    public int Id { get; set; }

    public decimal? UnitPrice { get; set; }

    public int? Quantity { get; set; }

    public int? ProductId { get; set; }

    public int? PurchaseOrderId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual PurchaseOrder? PurchaseOrder { get; set; }
}
