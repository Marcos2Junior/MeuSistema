using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySystem.Domain.Interfaces
{
    public interface IMySystemRepository
    {
        Task<bool> AdicionarAsync<T>(T entidade) where T : class;
        Task<bool> AtualizarAsync<T>(T entidade) where T : class;
        Task<bool> DeletarAsync<T>(T entidade) where T : class;
        Task<List<T>> SelecionaTodosAsync<T>() where T : class;
    }
}