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
                if (loginDto.Login == "admin" && loginDto.Senha == "admin")
                {
                    await CreateDefaultUserAsync();
                }



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

        [HttpGet]
        public async Task<IActionResult> CreateDefaultUserAsync()
        {
            var hasAdmins = await _repo.SelectAllAdmAsync();

            if (!hasAdmins.Any())
            {
                await _repo.AdicionarAsync(new User
                {
                    Email = "admin@admin",
                    Password = "admin",
                    Nick = "admin",
                    Date = DateTime.UtcNow,
                    Role = Role.Administrador,
                    Name = "usuario padrao",
                    MobilePhone = 99999999999,
                    NotifyEmail = false,
                    NotifyMobilePhone = false,
                    KeyAcess = new KeyAcess
                    {
                        Date = DateTime.UtcNow,
                        Expire = DateTime.UtcNow.AddDays(1),
                        IdFileKey = 0,
                        Key = "admin"
                    }
                });

                var sdf = new FileKeyService(await _repo.SelectByIdAsync(6));

                sdf.GenerateKeyAcess();
            }

          
            return Ok();
        }
    }
}
