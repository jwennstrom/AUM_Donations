using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUM.Domain
{
    public class Donation
    {
        protected internal virtual int DonationId { get; set; }
        public virtual Donor Donor { get; set; }
        public virtual DateTime? DateOfDonation { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual DateTime? CreatedOn { get; set; }
    }
}
