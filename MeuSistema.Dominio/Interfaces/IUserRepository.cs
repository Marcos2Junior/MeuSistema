using MySystem.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySystem.Domain.Interfaces
{
    public interface IUserRepository : IMySystemRepository
    {
        Task<User> SelectByIdAsync(int id);
        Task<List<User>> SelectAllAdmAsync();

        Task<User> SelectDynamicAsync(string value, string password);
    }
}
