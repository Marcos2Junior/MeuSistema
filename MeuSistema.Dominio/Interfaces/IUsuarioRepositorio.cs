using MeuSistema.Dominio.Entidades;
using System.Threading.Tasks;

namespace MeuSistema.Dominio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> SelecionaPorIdAsync(int id);
    }
}
