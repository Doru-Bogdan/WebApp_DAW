using System;
using DAW.Entities;
using DAW.Repositories;
using DAW.Data;
using DAW.IRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectDAW.IRepositories;

namespace ProiectDAW.Repositories
{
    public class UserDetailsRepository: GenericRepository<UserDetails>, IUserDetailsRepository
    {
        public UserDetailsRepository(DAWAppContext context): base(context)
        {
        }
    }
}
