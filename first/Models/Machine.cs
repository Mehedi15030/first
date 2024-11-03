using System;
using System.Collections.Generic;

namespace first.Models;

public partial class Machine
{
    public int MachineId { get; set; }

    public int LocationId { get; set; }

    public string SerialNumber { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string? Manufacturer { get; set; }

    public DateOnly InstallationDate { get; set; }

    public DateTime? LastMaintenanceDate { get; set; }

    public DateOnly? MaintenanceDueDate { get; set; }

    public decimal? Temperature { get; set; }

    public int Capacity { get; set; }

    public decimal? CurrentCashBalance { get; set; }

    public string? SoftwareVersion { get; set; }

    public virtual ICollection<ErrorLog> ErrorLogs { get; set; } = new List<ErrorLog>();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual Location Location { get; set; } = null!;

    public virtual ICollection<MaintenanceLog> MaintenanceLogs { get; set; } = new List<MaintenanceLog>();

    public virtual ICollection<Transactiontable> Transactiontables { get; set; } = new List<Transactiontable>();
}
