using DAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.IServices
{
    public interface IUserDetailsService
    {
        List<UserDetails> GetAll();
        UserDetails GetById(int id);
        bool Insert(UserDetails userDetails);
        bool Update(UserDetails userDetails);
        bool Delete(int id);
    }
}
