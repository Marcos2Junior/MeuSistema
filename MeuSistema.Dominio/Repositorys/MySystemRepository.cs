using Microsoft.EntityFrameworkCore;
using MySystem.Domain.DataContext;
using MySystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MySystem.Domain.Repositorys
{
    public class MySystemRepository : IMySystemRepository
    {
        protected readonly MySystemDbContext _context;
        public async Task<bool> AdicionarAsync<T>(T entidade) where T : class
        {
            await _context.AddAsync<T>(entidade);
            return await SalvarAsync();
        }

        public async Task<bool> AtualizarAsync<T>(T entidade) where T : class
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

        public async Task<bool> DeletarAsync<T>(T entidade) where T : class
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

        public async Task<List<T>> SelecionaTodosAsync<T>() where T : class
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
