using System;
using System.Collections.Generic;

namespace first.Models;

public partial class PurchaseOrderItem
{
    public int PoItemId { get; set; }

    public int PoId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalPrice { get; set; }

    public int? ReceivedQuantity { get; set; }

    public virtual PurchaseOrder Po { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
