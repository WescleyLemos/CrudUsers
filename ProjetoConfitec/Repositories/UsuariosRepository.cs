using Microsoft.EntityFrameworkCore;
using ProjetoConfitec.Data;
using ProjetoConfitec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoConfitec.Repositories
{
    public class UsuariosRepository
    {
        private readonly TesteConfitecContext _dbContext;
        public UsuariosRepository(TesteConfitecContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Adicionar(Usuarios usuario)
        {
            try
            {
                await _dbContext.Usuarios.AddAsync(usuario);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<Usuarios> ObterPorId(Guid id)
        {
            return await _dbContext.Usuarios.FindAsync(id);
        }

        public async Task<bool> Atualizar(Usuarios usuario)
        {
            try
            {
                _dbContext.Entry(usuario).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Remover(Guid id)
        {
            try
            {
                var usuario = await ObterPorId(id);
                _dbContext.Usuarios.Remove(usuario);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Usuarios>> ObterTodos()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }


    }
}
