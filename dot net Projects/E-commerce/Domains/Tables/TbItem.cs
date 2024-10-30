using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domains.Tables;

public partial class TbItem
{
    [ValidateNever]
    public int ItemId { get; set; }
    [Required]
    public string ItemName { get; set; } = null!;
    [Required]
    public decimal SalesPrice { get; set; }
    [Required]
    public decimal PurchasePrice { get; set; }
    [Required]
    public int CategoryId { get; set; }
    [ValidateNever]
    public string? ImageName { get; set; }
    [ValidateNever]
    public DateTime CreatedDate { get; set; }
    [ValidateNever]
    public string CreatedBy { get; set; } = null!;
    [ValidateNever]
    public int CurrentState { get; set; }
    [ValidateNever]
    public string? UpdatedBy { get; set; }
    [ValidateNever]
    public DateTime? UpdatedDate { get; set; }
    [ValidateNever]
    public string? Description { get; set; }
    [Required]
    public string? Gpu { get; set; }
    [Required]
    public string? HardDisk { get; set; }
    [Required]
    public int ItemTypeId { get; set; }
    [Required]
    public string? Processor { get; set; }
    [Required]
    public int RamSize { get; set; }
    [Required]
    public string? ScreenReslution { get; set; }
    [Required]
       public string? ScreenSize { get; set; }
    [Required]
    public string? Weight { get; set; }
    [Required]
    public int OsId { get; set; }
    [ValidateNever]
    [JsonIgnore]
    public virtual TbCategory Category { get; set; } = null!;
    [ValidateNever]
    [JsonIgnore]
    public virtual TbItemType ItemType { get; set; } = null!;
    [ValidateNever]
    [JsonIgnore]
    public virtual TbO Os { get; set; } = null!;
    [ValidateNever]
    [JsonIgnore]
    public virtual ICollection<TbItemDiscount> TbItemDiscounts { get; } = new List<TbItemDiscount>();
    [ValidateNever]
    [JsonIgnore]
    public virtual ICollection<TbItemImage> TbItemImages { get; } = new List<TbItemImage>();
    [ValidateNever]
    [JsonIgnore]
    public virtual ICollection<TbPurchaseInvoiceItem> TbPurchaseInvoiceItems { get; } = new List<TbPurchaseInvoiceItem>();
    [ValidateNever]
    [JsonIgnore]
    public virtual ICollection<TbSalesInvoiceItem> TbSalesInvoiceItems { get; } = new List<TbSalesInvoiceItem>();
    [ValidateNever]
    [JsonIgnore]
    public virtual ICollection<TbCustomer> Customers { get; } = new List<TbCustomer>();
}
