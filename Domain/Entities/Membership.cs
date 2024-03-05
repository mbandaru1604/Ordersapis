using System;
using System.Collections.Generic;

namespace DataAccess.EFCore.Models
{
    public partial class Membership
    {
        public Membership()
        {
            UserMemberships = new HashSet<UserMembership>();
        }

        public Guid MembershipId { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }

        public virtual ICollection<UserMembership> UserMemberships { get; set; }
    }
}
