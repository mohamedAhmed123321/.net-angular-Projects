using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domains.Tables;

public partial class TbCustomer
{
    [ValidateNever]
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;
    [ValidateNever]
    [JsonIgnore]
    public virtual TbBusinessInfo? TbBusinessInfo { get; set; }
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
    public virtual ICollection<TbItem> Items { get; } = new List<TbItem>();
}
