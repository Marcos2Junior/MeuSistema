using MySystem.Domain.Entitys;
using MySystem.Domain.Models.ResultRepository;
using System.Threading.Tasks;

namespace MySystem.Domain.Interfaces
{
    public interface IUserRepository : IMySystemRepository
    {
        Task<User> SelectByIdAsync(int id);

        Task<ResultDefault> VerifyLoginAsync(string value, string password);
    }
}
