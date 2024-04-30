using System;
using System.Collections.Generic;

namespace AlphaShop.Data;

public partial class Ord
{
    public int OrdId { get; set; }

    public int CartId { get; set; }

    public int StaffId { get; set; }

    public bool? OrdStatus { get; set; }

    public string? OrdDest { get; set; }

    public decimal? OrdPrice { get; set; }

    public DateTime? OrdDate { get; set; }

    public string? OrdNote { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual Customer Staff { get; set; } = null!;
}
