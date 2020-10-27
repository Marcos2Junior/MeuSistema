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
                               UserManager<User> userManager,
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
                if (loginDto.Login == "admin" && loginDto.Senha == "admin")
                {
                    await CreateDefaultUserAsync();
                }

                //User user = await _userManager.FindByLoginAsync(loginDto.Login);


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

        private async Task CreateDefaultUserAsync()
        {
            var hasAdmins = await _repo.SelectAllAdmAsync();

            if (!hasAdmins.Any())
            {
                await _repo.AdicionarAsync(new User
                {
                    Login = "admin",
                    Password = "admin",
                    Date = DateTime.Now,
                    Role = Role.Administrador,
                    Name = "usuario padrao"
                });
            }
        }
    }
}
