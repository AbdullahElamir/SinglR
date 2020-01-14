using System;
using System.Collections.Generic;

namespace Managegment.Models
{
    public partial class CourseFiles
    {
        public long CourseFileId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Pdf { get; set; }
        public long? CourseId { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public short Status { get; set; }
        public Courses Course { get; set; }
    }
}
