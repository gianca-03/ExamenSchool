using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class OnlineCourse
    {
        public int CourseId { get; set; }
        public string Url { get; set; } = null!;

        public virtual Course Course { get; set; } = null!;
    }
}
