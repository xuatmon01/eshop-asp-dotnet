﻿using eShopSolution.Application.System.Users;
using eShopSolution.ViewModels.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace eShopSolution.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous] // chưa đăng nhập vẫn có thể dc gọi hàm này


        public async Task<IActionResult>Authenticate([FromBody] LoginRequest request)
        {

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.Authenticate(request);


            if(String.IsNullOrEmpty(result))
            {
                return BadRequest("Username or password is incorrect !");
            }

            //trả về cái token

            return Ok(result);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> register([FromBody] RegisterRequest request)
        { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.Register(request);

            if (!result)
            {
                return BadRequest("Register is unsuccessful !");
            }

            return Ok(result);
        }
    }
}
