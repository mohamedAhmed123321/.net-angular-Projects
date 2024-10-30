using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains.Tables;

public partial class TbSlider
{
    [ValidateNever]
    public int SliderId { get; set; }
    [ValidateNever]
    public string? Title { get; set; }
    [ValidateNever]
    public string? Description { get; set; }
    [ValidateNever]
    public string ImageName { get; set; } = null!;
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
