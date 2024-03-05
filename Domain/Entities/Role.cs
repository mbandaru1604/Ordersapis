using System;
using System.Collections.Generic;

namespace DataAccess.EFCore.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public Guid RoleId { get; set; }
        public string RoleCode { get; set; } = null!;
        public string? RoleName { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
