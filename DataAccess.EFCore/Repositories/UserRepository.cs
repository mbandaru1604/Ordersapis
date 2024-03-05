using DataAccess.EFCore.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repositories
{
    public class UserRepository:GenericRepository<MN_PSCContext,User>,IUserRepository
    {
        private readonly MN_PSCContext _mmContext;
        public UserRepository(MN_PSCContext mnContext):base(mnContext)
        {
            _mmContext = mnContext;
        }
        public Task<List<User>> GetAllUsers()
        {
            return null;

        }
    }
}
