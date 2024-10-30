using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
    public class Details
    {
        public int CourseId { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string ImageName { get; set; } = null!;

        public int InstructorId { get; set; }

        public decimal? BookingPrice { get; set; }

        public int CourseTypeId { get; set; }

        public string Video { get; set; } = null!;

        public string CourseName { get; set; } = null!;

        public string Lectures { get; set; } = null!;

        public string SkillLevel { get; set; } = null!;

        public string Time { get; set; } = null!;

        public string? Minute { get; set; }

        public int CurrentState { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedBy { get; set; }
        public string InstructorName { get; set; } = null!;

    }
}
