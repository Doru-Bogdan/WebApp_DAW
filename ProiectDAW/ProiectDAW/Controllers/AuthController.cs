using DAW.Entities;
using DAW.IServices;
using Laborator4_453.Helpers;
using Laborator4_453.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(AuthenticationRequest request)
        {
            return Ok(_userService.Register(request));
        }

        [HttpPost("login")]
        public IActionResult Login(AuthenticationRequest request)
        {
            return Ok(_userService.Login(request));
        }

        [HttpGet("isAuth")]
        [Authorize]
        public IActionResult IsAuth()
        {
            return Ok(true);
        }

        [HttpGet("getAll")]
        [Authorize]
        public IActionResult GetAll()
        {
            var response = _userService.GetAll();
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }

        [HttpPost("carLoan")]
        [Authorize]
        public IActionResult CarLoan(CarLoan request)
        {
            request.StartLoanDate = DateTime.Now;
            return Ok(_userService.LoanCar(request));
        }

        [HttpGet("getCarsLoaned/{id}")]
        [Authorize]
        public IActionResult GetCarLoaned(int id)
        {
            return Ok(_userService.getLoanedCars(id));
        }

        [HttpGet("getUserDetails/{id}")]
        [Authorize]
        public IActionResult GetUserDetails(int id)
        {
            return Ok(_userService.getUserDetails(id));
        }
    }

}
