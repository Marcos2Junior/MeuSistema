using Microsoft.EntityFrameworkCore;
using MySystem.Domain.DataContext;
using MySystem.Domain.Entitys;
using MySystem.Domain.Enums;
using MySystem.Domain.Interfaces;
using MySystem.Domain.Models.ResultRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySystem.Domain.Repositorys
{
    public class UserRepository : MySystemRepository, IUserRepository
    {
        public UserRepository(MySystemDbContext context) : base(context)
        {
        }

        public async Task<User> SelectByIdAsync(int id) => await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<ResultDefault> VerifyLoginAsync(string value, string password)
        {
            ResultDefault resultDefault = new ResultDefault
            {
                Sucess = false,
                Message = "Usuario ou senha invalido",
                HttpStatusCode = System.Net.HttpStatusCode.NotFound
            };

            value = value.ToLower().Trim();

            var _user = await _context.Users
                .Include(x => x.Passwords)
                .FirstOrDefaultAsync(x =>
                x.Email == value || x.MobilePhone.ToString() == value);

            if (_user != null)
            {
                var passwords = _user.Passwords.Where(x =>
                x.TypePassword.Name == TypePasswordsDefault.Sistema.ToString());

                if (!passwords.Any())
                {
                    var lastPassword = passwords.LastOrDefault();

                    if (lastPassword != null && lastPassword.Pass == password)
                    {
                        resultDefault.Sucess = true;
                        resultDefault.HttpStatusCode = System.Net.HttpStatusCode.OK;
                        resultDefault.Message = "Usuario e senha valido";
                    }
                    else
                    {
                        //Pegar a data de quando foi adicionado a proxima senha para exibir no message a data que foi alterado
                        var OldPassword = passwords.FirstOrDefault(x => x.Pass == password);

                        if(OldPassword != null)
                        {
                            resultDefault.Message = "Senha invalida. Voce inseriu uma senha antiga.";
                        }
                    }
                }
                else
                {
                    //Garantir que o usuario sempre vá ter ao menos um registro
                    throw new System.Exception("Registro de senha de acesso ao sistema nao encontrado");
                }
            }

            return resultDefault;
        }
    }
}
