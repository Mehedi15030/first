using System;
using System.Collections.Generic;

namespace first.Models;

public partial class TransactionItem
{
    public int ItemId { get; set; }

    public int TransactionId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Transactiontable Transaction { get; set; } = null!;
}
