using System;
using System.Collections.Generic;

namespace DataAccess.EFCore.Models
{
    public partial class UserMembership
    {
        public Guid UserId { get; set; }
        public Guid MembershipId { get; set; }
        public DateTime? Validity { get; set; }
        public bool? ExtendMembership { get; set; }
        public short? ExtendDays { get; set; }

        public virtual Membership Membership { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
