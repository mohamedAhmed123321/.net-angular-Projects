using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domains.Tables;

public partial class TbSupplier
{
    [ValidateNever]
    public int SupplierId { get; set; }
    [Required(ErrorMessage = "please enter Supplier Name")]
    public string SupplierName { get; set; } = null!; 
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
    public virtual ICollection<TbPurchaseInvoice> TbPurchaseInvoices { get; } = new List<TbPurchaseInvoice>();
}
