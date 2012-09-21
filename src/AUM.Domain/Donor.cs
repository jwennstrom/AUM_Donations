using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace AUM.Domain
{
    public class Donor
    {
        protected internal virtual int DonorId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Phone { get; set; }
        public virtual DateTime? CreatedOn { get; set; }
        public virtual IList<Donation> Donations { get; set; }
    }
}
