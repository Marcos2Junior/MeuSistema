using Microsoft.EntityFrameworkCore;
using MySystem.Domain.Entitys;
using MySystem.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySystem.Domain.Repositorys
{
    public class UserRepository : MySystemRepository, IUserRepository
    {
        public async Task<List<User>> SelectAllAdmAsync() =>
            await _context.Users.Where(x => x.Role == Enums.Role.Administrador).ToListAsync();
       

        public async Task<User> SelectByIdAsync(int id) => await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<User> SelectDynamicAsync(string value, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Login == value && x.Password == password);
        }
    }
}
