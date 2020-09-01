using MeuSistema.Dominio.Entidades;
using MeuSistema.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeuSistema.Dominio.Repositorios
{
    public class UsuarioRepositorio : Crud<UsuarioRepositorio>, IUsuarioRepositorio
    {
        public Task<Usuario> SelecionaPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
