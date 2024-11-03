using System;
using System.Collections.Generic;

namespace first.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? DisplayOrder { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
