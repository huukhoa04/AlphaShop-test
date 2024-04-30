using System;
using System.Collections.Generic;

namespace AlphaShop.Data;

public partial class Product
{
    public int PrdId { get; set; }

    public int CgrId { get; set; }

    public string? PrdName { get; set; }

    public int? PrdStatus { get; set; }

    public decimal? PrdPrice { get; set; }

    public string? PrdDesc { get; set; }

    public string? PrdImage { get; set; }

    public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

    public virtual Category Cgr { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
