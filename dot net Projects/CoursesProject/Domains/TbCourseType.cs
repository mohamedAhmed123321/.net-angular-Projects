using System;
using System.Collections.Generic;

namespace Domains
{

    public partial class TbCourseType
    {
        public int CourseTypeId { get; set; }

        public string CourseTypeName { get; set; } = null!;

        public int CurrentState { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedBy { get; set; }

        public virtual ICollection<TbCourse> TbCourses { get; set; } = new List<TbCourse>();
    }
}