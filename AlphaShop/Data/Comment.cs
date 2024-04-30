using System;
using System.Collections.Generic;

namespace AlphaShop.Data;

public partial class Comment
{
    public int CommentId { get; set; }

    public int CtrId { get; set; }

    public int PrdId { get; set; }

    public string? CommentText { get; set; }

    public int? Upvote { get; set; }

    public virtual Customer Ctr { get; set; } = null!;

    public virtual Product Prd { get; set; } = null!;
}
