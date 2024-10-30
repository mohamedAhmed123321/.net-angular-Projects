using System;
using System.Collections.Generic;

namespace Domains
{

    public partial class TbCustomerCourse
    {
        public int CustomerCourseId { get; set; }

        public int CourseId { get; set; }

        public int CustomerId { get; set; }

        public decimal PaymentValue { get; set; }

        public int? PaymentMethodId { get; set; }

        public int CurrentState { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedBy { get; set; }

        public virtual TbCourse Course { get; set; } = null!;

        public virtual TbCustomer CourseNavigation { get; set; } = null!;

        public virtual TbPaymentMethod? PaymentMethod { get; set; }
    }
}