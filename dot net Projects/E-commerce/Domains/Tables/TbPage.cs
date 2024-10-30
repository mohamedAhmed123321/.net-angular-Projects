using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace Domains.Tables;

public partial class TbPage
{
    [ValidateNever]
    public int PageId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string MetaKeyWord { get; set; } = null!;

    public string MetaDescriptiuon { get; set; } = null!;
    [ValidateNever]
    public string ImageName { get; set; } = null!;
    [ValidateNever]
    public int CurrentState { get; set; }
    [ValidateNever]
    public DateTime CreatedDate { get; set; }
    [ValidateNever]
    public string CreatedBy { get; set; } = null!;
    [ValidateNever]
    public DateTime? UpdatedDate { get; set; }
    [ValidateNever]

    public string? UpdatedBy { get; set; }
}
