using Microsoft.EntityFrameworkCore.Internal;
using MySystem.Domain.Entitys;
using MySystem.Domain.Enums;
using MySystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySystem.Domain.Services
{
    public class StartDbService
    {
        private readonly IMySystemRepository _repository;

        public StartDbService(IMySystemRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateDefaultAsync()
        {
            var typePasswordDefaultSistema = await GetTypePasswordAsync(TypePasswordsDefault.Sistema);

            if (typePasswordDefaultSistema == null)
            {
                await _repository.AdicionarAsync(new TypePassword
                {
                    Name = TypePasswordsDefault.Sistema.ToString(),
                    Global = true,
                    Order = 1
                });
            }

            var _users = await _repository.SelecionaTodosAsync<User>();

            if (!_users.Any())
            {
                typePasswordDefaultSistema = await GetTypePasswordAsync(TypePasswordsDefault.Sistema);

                await _repository.AdicionarAsync(new User
                {
                    Email = "admin@admin",
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
                        Expire = DateTime.UtcNow.AddMinutes(1),
                        DateConfirmed = DateTime.UtcNow,
                        Key = 12345,
                        Acess = Acess.email
                    },
                    Passwords = new List<Password>
                    {
                        new Password
                        {
                            Pass = "admin",
                            TypePassword = typePasswordDefaultSistema,
                            TypePasswordId = typePasswordDefaultSistema.Id,
                            DateTime = DateTime.UtcNow
                        }
                    }
                });
            }
        }

        private async Task<TypePassword> GetTypePasswordAsync(TypePasswordsDefault typePasswordsDefault)
        {
            var typesPasswords = await _repository.SelecionaTodosAsync<TypePassword>();

            return typesPasswords.FirstOrDefault(x => x.Name == typePasswordsDefault.ToString());
        }
    }
}
