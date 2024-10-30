using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domains.Tables;

public partial class TbCategory
{
    [ValidateNever]
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;
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
    public string ImageName { get; set; } = null!;
    [ValidateNever]
    public bool ShowInHomePage { get; set; }


    [ValidateNever]
    [JsonIgnore]
    public virtual ICollection<TbItem> TbItems { get; } = new List<TbItem>();
}
