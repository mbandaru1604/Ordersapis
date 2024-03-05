using System;
using System.Collections.Generic;

namespace DataAccess.EFCore.Models
{
    public partial class BioDatum
    {
        public Guid BioDataId { get; set; }
        public Guid UserId { get; set; }
        public string? MarriageType { get; set; }
        public string? Gothram { get; set; }
        public string? Nakshatram { get; set; }
        public short? Paadam { get; set; }
        public string? MoleIdentity { get; set; }
        public DateTime? Dob { get; set; }
        public string? BirthLocation { get; set; }
        public string? CurrentAddress1 { get; set; }
        public string? CurrentAddress2 { get; set; }
        public string? City { get; set; }
        public string? Mandal { get; set; }
        public string? District { get; set; }
        public short? Pin { get; set; }
        public string? Country { get; set; }
        public string? Religion { get; set; }
        public string? MotherToungue { get; set; }
        public string? Qualification { get; set; }
        public string? Profession { get; set; }
        public short? AnnualIncome { get; set; }
        public string? JobLocation { get; set; }
        public string? Hobbies { get; set; }
        public string? AdditionalInfo { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
