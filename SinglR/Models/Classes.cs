using System;
using System.Collections.Generic;

namespace Managegment.Models
{
    public partial class Classes
    {
        public long ClassId { get; set; }
        public string ClassName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Agenda { get; set; }
        public int? ClassType { get; set; }
        public string Teacher { get; set; }
        public string Location { get; set; }
        public long SuperPackageId { get; set; }
        public long PackageId { get; set; }
        public long? CourseId { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public short Status { get; set; }
    }
}
