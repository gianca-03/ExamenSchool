using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class StudentGrade
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public decimal? Grade { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Person Student { get; set; } = null!;
    }
}
