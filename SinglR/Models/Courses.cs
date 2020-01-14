using System;
using System.Collections.Generic;

namespace Managegment.Models
{
    public partial class Courses
    {
        public Courses()
        {
            CourseFiles = new HashSet<CourseFiles>();
        }

        public long CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PricePersonal { get; set; }
        public decimal PriceCompany { get; set; }
        public int Discount { get; set; }
        public string Color { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public short Status { get; set; }
        public long? PackageId { get; set; }
        public long? SuperPackageId { get; set; }

        public Packages Package { get; set; }
        public SuperPackages SuperPackage { get; set; }
        public ICollection<CourseFiles> CourseFiles { get; set; }
    }
}
