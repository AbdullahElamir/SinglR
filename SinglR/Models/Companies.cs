using System;
using System.Collections.Generic;

namespace Managegment.Models
{
    public partial class Companies
    {
        public Companies()
        {
            Students = new HashSet<Students>();
        }

        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public short Status { get; set; }
        public string BoughtBy { get; set; }
        public string Communicator { get; set; }

        public ICollection<Students> Students { get; set; }
    }
}
