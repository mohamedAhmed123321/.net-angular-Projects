using System;
using System.Collections.Generic;

namespace Domains.ViewResult;

public partial class VwItemCategory
{
    public string ItemName { get; set; } = null!;

    public decimal SalesPrice { get; set; }

    public string CategoryName { get; set; } = null!;

    public decimal PurchasePrice { get; set; }

    public string? ImageName { get; set; }

    public int ItemId { get; set; }

    public int CategoryId { get; set; }
    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public int CurrentState { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
