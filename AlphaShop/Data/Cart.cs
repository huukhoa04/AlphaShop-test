using System;
using System.Collections.Generic;

namespace AlphaShop.Data;

public partial class Cart
{
    public int CartId { get; set; }

    public int? CartQuantity { get; set; }

    public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

    public virtual Customer CartNavigation { get; set; } = null!;

    public virtual ICollection<Ord> Ords { get; set; } = new List<Ord>();
}
