﻿using DatingApp2.API.Data;
using DatingApp2.API.Dtos;
using DatingApp2.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegister userForRegister)
        {
            userForRegister.Username = userForRegister.Username.ToLower();
            if (await _repo.UserExists(userForRegister.Username))
                return BadRequest("Username already exists");

            var userToCreate = new User
            {
                Username = userForRegister.Username
            };

            var createdUser = await _repo.Register(userToCreate, userForRegister.Password);

            return StatusCode(201);
        }
    }
}
