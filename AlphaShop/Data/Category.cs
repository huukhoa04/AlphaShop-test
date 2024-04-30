using System;
using System.Collections.Generic;

namespace AlphaShop.Data;

public partial class Category
{
    public int CgrId { get; set; }

    public string? CgrName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
