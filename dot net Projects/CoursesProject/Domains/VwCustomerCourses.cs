using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class VwCustomerCourses
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; } = null!;
        public string CourseName { get; set; } = null!;
        public decimal PaymentValue { get; set; }
        public decimal Price { get; set; }
        public string ImageName { get; set; } = null!;

    }
}
