using Microsoft.AspNetCore.Http;
using MySystem.API.Services.pgp;
using MySystem.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySystem.API.Services
{
    public class FileKeyService
    {
        private readonly User _user;
        private readonly string _pathKeyAcess;

        public FileKeyService(User user)
        {
            _user = user;
            _pathKeyAcess = Path.Combine(@"D:\Projetos\MySystem\MeuSistema.API\Resources", "KeyAcess");
        }

        public KeyAcess GenerateKeyAcess()
        {
            new EncryptDecrypt(_user).
                EncryptAndSign(Path.Combine(_pathKeyAcess, $"{_user.Id}.txt"),
                Path.Combine(_pathKeyAcess, $"{_user.Id}"));

            new EncryptDecrypt(_user).Decrypt(Path.Combine(_pathKeyAcess, $"{_user.Id}"), Path.Combine(_pathKeyAcess, $"{_user.Id}.txt"));

            KeyAcess keyAcess = new KeyAcess
            {

            };

            return keyAcess;
        }
    }
}
