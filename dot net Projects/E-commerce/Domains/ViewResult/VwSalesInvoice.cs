using System;
using System.Collections.Generic;

namespace Domains.ViewResult;

public partial class VwSalesInvoice
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int InvoiceId { get; set; }

    public DateTime InvoiceDate { get; set; }

    public DateTime DelivryDate { get; set; }

    public int? DelivryManId { get; set; }

    public string? Notes { get; set; }

    public Guid CustomerId { get; set; }
    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public int CurrentState { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
