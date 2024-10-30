using System;
using System.Collections.Generic;

namespace Domains
{

    public partial class TbCustomer
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int CurrentState { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedBy { get; set; }

        public virtual ICollection<TbCustomerCourse> TbCustomerCourses { get; set; } = new List<TbCustomerCourse>();
    }
}