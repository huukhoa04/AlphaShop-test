using System;
using System.Collections.Generic;

namespace AlphaShop.Data;

public partial class Access
{
    public int AccId { get; set; }

    public string? AccName { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
