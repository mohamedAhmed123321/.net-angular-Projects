using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domains.Tables;

public partial class TbPurchaseInvoice
{
    [ValidateNever]
    public int InvoiceId { get; set; }

    public DateTime InvoiceDate { get; set; }

    public int SupplierId { get; set; }
    [ValidateNever]
    public string? Notes { get; set; }
    [ValidateNever]
    [JsonIgnore]
    public virtual TbSupplier Supplier { get; set; } = null!;
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
    public virtual ICollection<TbPurchaseInvoiceItem> TbPurchaseInvoiceItems { get; } = new List<TbPurchaseInvoiceItem>();
}
