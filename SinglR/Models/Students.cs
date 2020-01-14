using System;
using System.Collections.Generic;

namespace Managegment.Models
{
    public partial class Students
    {
        public int StudentId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Nationality { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string CurrentJob { get; set; }
        public int? ExperinceNumbers { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public short Status { get; set; }
        public long? CompanyId { get; set; }

        public Companies Company { get; set; }
    }
}
