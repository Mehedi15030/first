using System;
using System.Collections.Generic;

namespace first.Models;

public partial class PaymentDetail
{
    public int PaymentId { get; set; }

    public int TransactionId { get; set; }

    public decimal Amount { get; set; }

    public string? Currency { get; set; }

    public string? AuthorizationCode { get; set; }

    public virtual Transactiontable Transaction { get; set; } = null!;
}
