using System;
using System.Collections.Generic;

namespace first.Models;

public partial class PurchaseOrder
{
    public int PoId { get; set; }

    public int SupplierId { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public decimal TotalAmount { get; set; }

    public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();

    public virtual Supplier Supplier { get; set; } = null!;
}
