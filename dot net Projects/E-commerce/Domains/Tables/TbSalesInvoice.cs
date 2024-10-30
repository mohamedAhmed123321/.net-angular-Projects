using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domains.Tables;

public partial class TbSalesInvoice
{
    [ValidateNever]
    public int InvoiceId { get; set; }

    public DateTime InvoiceDate { get; set; }

    public DateTime DelivryDate { get; set; }
    [ValidateNever]
    public int? DelivryManId { get; set; }
    [ValidateNever]
    public string? Notes { get; set; }

    public Guid CustomerId { get; set; }
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
    public virtual ICollection<TbSalesInvoiceItem> TbSalesInvoiceItems { get; } = new List<TbSalesInvoiceItem>();
}
