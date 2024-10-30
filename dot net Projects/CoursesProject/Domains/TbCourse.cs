using System;
using System.Collections.Generic;

namespace Domains
{


    public partial class TbCourse
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

        public virtual TbCourseType CourseType { get; set; } = null!;

        public virtual TbInstructor Instructor { get; set; } = null!;

        public virtual ICollection<TbCustomerCourse> TbCustomerCourses { get; set; } = new List<TbCustomerCourse>();

        public virtual ICollection<TbFeature> TbFeatures { get; set; } = new List<TbFeature>();
    }
}