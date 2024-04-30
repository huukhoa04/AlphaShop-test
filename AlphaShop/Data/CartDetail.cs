using System;
using System.Collections.Generic;

namespace AlphaShop.Data;

public partial class CartDetail
{
    public int CartId { get; set; }

    public int PrdId { get; set; }

    public int? Quantity { get; set; }

    public int OptionSize { get; set; }

    public int OptionType { get; set; }

    public string? Note { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual Product Prd { get; set; } = null!;
}
