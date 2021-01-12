using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAW.Entities;
using DAW.Enums;
using Laborator4_453.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectDAW.IServices;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly IUserDetailsService _service;
        public UserDetailsController(IUserDetailsService service)
        {
            this._service = service;
        }

        [HttpGet("all")]
        [Authorize]
        public IActionResult GetAll()
        {
            var response = _service.GetAll();
            return Ok(response);
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            var response = _service.GetById(id);
            return Ok(response);
        }

        [HttpPost("update")]
        [Authorize]
        public IActionResult Update(UserDetails payload)
        {
            _service.Update(payload);
            return Ok();
        }

        [HttpPost("create")]
        [Authorize]
        public IActionResult Create(UserDetails payload)
        {
            _service.Insert(payload);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }

        private User GetUserFromContext() =>
            (User)HttpContext.Items["User"];
    }
}
