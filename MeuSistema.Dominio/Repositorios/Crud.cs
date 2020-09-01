using MeuSistema.Dominio.DbContexto;
using MeuSistema.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuSistema.Dominio.Repositorios
{
    public class Crud<T> : ICrud<T> where T : class
    {
        protected readonly MeuSistemaDbContexto _context;
        public async Task<bool> AdicionarAsync(T entidade)
        {
            await _context.AddAsync<T>(entidade);
            return await SalvarAsync();
        }

        public async Task<bool> AtualizarAsync(T entidade)
        {
            if (_context.Entry<T>(entidade).State == EntityState.Detached)
            {
                _context.Attach(entidade);
                _context.Entry(entidade).State = EntityState.Modified;
            }
            else
            {
                _context.Update(entidade);
            }

            return await SalvarAsync();
        }

        public async Task<bool> DeletarAsync(T entidade)
        {
            try
            {
                _context.Remove(entidade);
                return await SalvarAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<T>> SelecionaTodosAsync()
        {
            var result = new List<T>();
            try
            {
                result = await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                //gravar log
            }
            return result;
        }

        private async Task<bool> SalvarAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() != 1;
            }
            catch (Exception ex)
            {
                //gravar log
                return false;
            }
        }
    }
}
