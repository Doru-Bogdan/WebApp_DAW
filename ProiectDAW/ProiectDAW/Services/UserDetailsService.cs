using DAW.Entities;
using ProiectDAW.IRepositories;
using ProiectDAW.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Services
{
    public class UserDetailsService: IUserDetailsService
    {
        private readonly IUserDetailsRepository _repository;
        public UserDetailsService(IUserDetailsRepository repository)
        {
            this._repository = repository;
        }

        public bool Delete(int id)
        {
            var student = _repository.FindById(id);
            _repository.Delete(student);
            return _repository.SaveChanges();
        }

        public List<UserDetails> GetAll()
        {
            return _repository.GetAllActive();
        }

        public UserDetails GetById(int id)
        {
            return _repository.FindById(id);
        }

        public bool Insert(UserDetails userDetails)
        {
            _repository.Create(userDetails);
            return _repository.SaveChanges();
        }

        public bool Update(UserDetails userDetails)
        {
            _repository.Update(userDetails);
            return _repository.SaveChanges();
        }
    }
}
