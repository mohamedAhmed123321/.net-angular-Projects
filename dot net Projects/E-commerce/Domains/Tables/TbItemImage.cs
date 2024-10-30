using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domains.Tables;

public partial class TbItemImage
{
    [ValidateNever]
    public int ImageId { get; set; }
    [ValidateNever]
    public string ImageName { get; set; } = null!;

    public int ItemId { get; set; }
    [ValidateNever]
    [JsonIgnore]
    public virtual TbItem Item { get; set; } = new TbItem();
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
