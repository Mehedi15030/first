using System;
using System.Collections.Generic;

namespace first.Models;

public partial class Inventory
{
    public int InventoryId { get; set; }

    public int MachineId { get; set; }

    public int ProductId { get; set; }

    public int SlotNumber { get; set; }

    public int CurrentQuantity { get; set; }

    public int Capacity { get; set; }

    public int? MinimumStock { get; set; }

    public decimal Price { get; set; }

    public DateTime? LastRestocked { get; set; }

    public virtual Machine Machine { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
