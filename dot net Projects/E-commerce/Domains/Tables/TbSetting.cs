using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains.Tables;

public partial class TbSetting
{
    [ValidateNever]
    public int Id { get; set; }
    [Required]
    public string WebsiteName { get; set; } = null!;
    [ValidateNever]
    public string Logo { get; set; } = null!;
    [Required]
    public string WebsiteDescription { get; set; } = null!;
    [Required]
    public string FacebookLink { get; set; } = null!;
    [Required]
    public string TwitterLink { get; set; } = null!;
    [Required]
    public string InstgramLink { get; set; } = null!;
    [Required]
    public string YoutubeLink { get; set; } = null!;
    [Required]
    public string MiddlePanner { get; set; } = null!;
    [Required]
    public string Address { get; set; } = null!;
    [Required]
    public string ContactNumber { get; set; } = null!;
    [Required]
    public string LastPanner { get; set; } = null!;
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
