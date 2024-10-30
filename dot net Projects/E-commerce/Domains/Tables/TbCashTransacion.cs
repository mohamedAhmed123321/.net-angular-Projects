using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace Domains.Tables;

public partial class TbCashTransacion
{
    [ValidateNever]
    public int CashTransactionId { get; set; }

    public int CustomerId { get; set; }

    public DateTime CashDate { get; set; }

    public decimal CashValue { get; set; }
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
}
