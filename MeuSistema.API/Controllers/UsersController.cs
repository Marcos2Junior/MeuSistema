using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MySystem.API.Dtos;
using MySystem.API.Services;
using MySystem.Domain.Entitys;
using MySystem.Domain.Enums;
using MySystem.Domain.Interfaces;

namespace MySystem.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository usuarioRepositorio,
                               IMapper mapper)
        {
            _repo = usuarioRepositorio;
            _mapper = mapper;
        }

        [HttpPost("login"), AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            try
            {
                

                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IActionResult> Register(UserInsertDto userInsertDto)
        {

            return Ok();
        }

    }
}
