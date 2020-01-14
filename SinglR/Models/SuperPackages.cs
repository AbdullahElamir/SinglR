using System;
using System.Collections.Generic;

namespace Managegment.Models
{
    public partial class SuperPackages
    {
        public SuperPackages()
        {
            Courses = new HashSet<Courses>();
            Packages = new HashSet<Packages>();
        }

        public long SuperPackageId { get; set; }
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
        public int? ContentType { get; set; }

        public ICollection<Courses> Courses { get; set; }
        public ICollection<Packages> Packages { get; set; }
    }
}
