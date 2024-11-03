using System;
using System.Collections.Generic;

namespace first.Models;

public partial class Transactiontable
{
    public int TransactionId { get; set; }

    public int MachineId { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime? TransactionDate { get; set; }

    public string? ReferenceNumber { get; set; }

    public virtual Machine Machine { get; set; } = null!;

    public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();

    public virtual ICollection<TransactionItem> TransactionItems { get; set; } = new List<TransactionItem>();
}
