using MeuSistema.Dominio.Entidades;
using MeuSistema.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MeuSistema.Dominio.Repositorios
{
    public class UsuarioRepositorio : Crud<UsuarioRepositorio>, IUsuarioRepositorio
    {
        public async Task<Usuario> SelecionaPorIdAsync(int id) => await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
    }
}
