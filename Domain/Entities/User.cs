using System;
using System.Collections.Generic;

namespace DataAccess.EFCore.Models
{
    public partial class User
    {
        public User()
        {
            BioData = new HashSet<BioDatum>();
            ProfileImages = new HashSet<ProfileImage>();
            UserMemberships = new HashSet<UserMembership>();
            Roles = new HashSet<Role>();
        }

        public Guid UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string UserName { get; set; } = null!;
        public string? Contact { get; set; }
        public string? AlternateContact { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string Password { get; set; } = null!;

        public virtual ICollection<BioDatum> BioData { get; set; }
        public virtual ICollection<ProfileImage> ProfileImages { get; set; }
        public virtual ICollection<UserMembership> UserMemberships { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
