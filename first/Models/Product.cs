using System;
using System.Collections.Generic;

namespace first.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Sku { get; set; }

    public decimal UnitCost { get; set; }

    public decimal RetailPrice { get; set; }

    public decimal? WeightGrams { get; set; }

    public int? ShelfLifeDays { get; set; }

    public string? ImageUrl { get; set; }

    public string? NutritionalInfo { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();

    public virtual ICollection<TransactionItem> TransactionItems { get; set; } = new List<TransactionItem>();
}
