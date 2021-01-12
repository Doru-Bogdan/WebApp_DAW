using DAW.Entities;
using DAW.Models;
using Laborator4_453.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.IServices
{
    public interface IUserService
    {
        User GetById(int id);
        List<User> GetAll();
        bool Register(AuthenticationRequest request);
        AuthenticationResponse Login(AuthenticationRequest request);
        bool Delete(int id);
        bool LoanCar(CarLoan payload);
        User getLoanedCars(int id);
        User getUserDetails(int id);
    }
}
