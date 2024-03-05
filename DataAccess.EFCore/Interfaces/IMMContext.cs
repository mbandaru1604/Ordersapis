using DataAccess.EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace DataAccess.EFCore.Interfaces
{
    public interface IMMContext
    {
         DbSet<BioDatum> BioData { get; set; }
         DbSet<Caste> Castes { get; set; } 
         DbSet<Membership> Memberships { get; set; } 
         DbSet<ProfileImage> ProfileImages { get; set; } 
         DbSet<Role> Roles { get; set; } 
         DbSet<User> Users { get; set; } 
         DbSet<UserMembership> UserMemberships { get; set; } 
    }
}
