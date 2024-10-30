using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domains.Tables;

public partial class TbPurchaseInvoiceItem
{
    [ValidateNever]
    public int InvoiceItemId { get; set; }

    public int ItemId { get; set; }

    public int InvoiceId { get; set; }

    public double Qty { get; set; }

    public decimal InvoicePrice { get; set; }
    [ValidateNever]
    public string? Notes { get; set; }
    [ValidateNever]
    [JsonIgnore]
    public virtual TbPurchaseInvoice Invoice { get; set; } = null!;
    [ValidateNever]
    public string CreatedBy { get; set; } = null!;
    [ValidateNever]
    public DateTime CreatedDate { get; set; }
    [ValidateNever]
    public int CurrentState { get; set; }
    [ValidateNever]
    public string? UpdatedBy { get; set; }
    [ValidateNever]
    public DateTime? UpdatedDate { get; set; }
    [ValidateNever]
    [JsonIgnore]
    public virtual TbItem Item { get; set; } = null!;
}
