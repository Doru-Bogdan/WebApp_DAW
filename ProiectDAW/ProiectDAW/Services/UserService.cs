using DAW.Entities;
using DAW.Enums;
using DAW.IRepositories;
using DAW.IServices;
using DAW.Models;
using Laborator4_453.Interfaces;
using Laborator4_453.Mapper;
using Laborator4_453.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProiectDAW.IRepositories;
using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAW.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepostiory;
        private readonly ICarLoanRepository _carLoanRepository;
        private readonly AppSettings _appSettings;

        public UserService(IUserRepository userRepository, ICarLoanRepository carLoanRepository, IOptions<AppSettings> appSettings)
        {
            this._userRepostiory = userRepository;
            this._carLoanRepository = carLoanRepository;
            this._appSettings = appSettings.Value;
        }

        public bool Register(AuthenticationRequest request)
        {
            var entity = request.ToUserExtension(Enums.UserTypeEnum.Student);

            _userRepostiory.Create(entity);
            return _userRepostiory.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _userRepostiory.GetAllActive();
        }

        public User GetById(int id)
        {
            return _userRepostiory.FindById(id);
        }

        public AuthenticationResponse Login(AuthenticationRequest request)
        {
            // find user
            var user = _userRepostiory.GetByUserAndPassword(request.Username, request.Password);
            if (user == null)
                return null;

            // attach token
            var token = GenerateJwtForUser(user);

            // return user & token
            return new AuthenticationResponse
            {
                Id = user.Id,
                Username = user.Username,
                Type = user.Type,
                Token = token
            };
        }

        private string GenerateJwtForUser(User user)
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool LoanCar(CarLoan payload)
        {
            _carLoanRepository.Create(payload);
            return _carLoanRepository.SaveChanges();
        }

        public User getLoanedCars(int id)
        {
            return _userRepostiory.GetUserWithLoanedCars(id);
        }

        public User getUserDetails(int id)
        {
            return _userRepostiory.GetUserWithDetails(id);
        }

        public bool Delete(int id)
        {
            var user = _userRepostiory.FindById(id);
            _userRepostiory.Delete(user);
            return _userRepostiory.SaveChanges();
        }
    }
}
