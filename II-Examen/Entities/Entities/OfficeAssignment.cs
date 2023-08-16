using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class OfficeAssignment
    {
        public int InstructorId { get; set; }
        public string Location { get; set; } = null!;
        public byte[] Timestamp { get; set; } = null!;

        public virtual Person Instructor { get; set; } = null!;
    }
}
