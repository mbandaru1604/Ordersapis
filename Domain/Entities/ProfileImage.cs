using System;
using System.Collections.Generic;

namespace DataAccess.EFCore.Models
{
    public partial class ProfileImage
    {
        public Guid ImageId { get; set; }
        public byte[]? Image { get; set; }
        public bool? IsPreferred { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
