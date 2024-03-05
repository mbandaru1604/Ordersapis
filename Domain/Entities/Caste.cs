using System;
using System.Collections.Generic;

namespace DataAccess.EFCore.Models
{
    public partial class Caste
    {
        public Guid CasteId { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
