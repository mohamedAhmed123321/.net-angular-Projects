using System;
using System.Collections.Generic;

namespace Domains {

public partial class TbFeature
{
    public int Featuresd { get; set; }

    public string FeatureName { get; set; } = null!;

    public int CousreId { get; set; }

        public int CurrentState { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedBy { get; set; }

        public virtual TbCourse Cousre { get; set; } = null!;
}
}