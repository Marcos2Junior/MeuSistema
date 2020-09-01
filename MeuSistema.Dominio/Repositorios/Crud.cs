using MeuSistema.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeuSistema.Dominio.Repositorios
{
    public class Crud<T> : ICrud<T> where T : class
    {
        public Task<bool> AdicionarAsync(T entidade)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AtualizarAsync(T entidade)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarAsync(T entidade)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> SelecionaTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
