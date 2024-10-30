using System;
using System.Collections.Generic;

namespace Domains.ViewResult;

public partial class VwItemsOutOfInvoice
{
    public string? ItemName { get; set; }

    public string CategoryName { get; set; } = null!;

    public decimal? InvoicePrice { get; set; }

    public decimal? PurchasePrice { get; set; }
    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public int CurrentState { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
