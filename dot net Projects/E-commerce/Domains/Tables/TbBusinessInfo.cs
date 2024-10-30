using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domains.Tables;

public partial class TbBusinessInfo
{
    [ValidateNever]
    public int BusinessInfoId { get; set; }
    [ValidateNever]
    public string? BusinessCardNumber { get; set; }
    [ValidateNever]

    public string? OfficePhone { get; set; }

    public decimal Budget { get; set; }

    public int CutomerId { get; set; }
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
    public virtual TbCustomer Cutomer { get; set; } = null!;
}
