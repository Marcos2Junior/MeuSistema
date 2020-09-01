using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuSistema.Dominio.Interfaces
{
    public interface ICrud<T> where T : class
    {
        Task<bool> AdicionarAsync(T entidade);
        Task<bool> AtualizarAsync(T entidade);
        Task<bool> DeletarAsync(T entidade);
        Task<IEnumerable<T>> SelecionaTodosAsync();
    }
}