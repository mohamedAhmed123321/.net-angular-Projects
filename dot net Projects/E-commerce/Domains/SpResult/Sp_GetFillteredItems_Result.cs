using Domains.ViewResult;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.SpResult
{
    public class Sp_GetFillteredItems_Result
    {
        public string ItemName { get; set; } = null!;

        public decimal PurchasePrice { get; set; }

        public decimal SalesPrice { get; set; }

        public int CategoryId { get; set; }

        public string? ImageName { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; } = null!;

        public int CurrentState { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? Description { get; set; }

        public string? Gpu { get; set; }

        public string? HardDisk { get; set; }

        public int? ItemTypeId { get; set; }

        public string? Processor { get; set; }

        public int? RamSize { get; set; }

        public string? ScreenReslution { get; set; }

        public string? ScreenSize { get; set; }

        public string? Weight { get; set; }

        public int? OsId { get; set; }

        public string CategoryName { get; set; } = null!;

        public string ItemTypeName { get; set; } = null!;

        public string OsName { get; set; } = null!;
        [Key]
        public int ItemId { get; set; }
        public int TotalPages { get; set; }
    }
}
