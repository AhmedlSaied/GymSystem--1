using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GymSystem.DAL.Contexts;
using GymSystem.DAL.Entities;
using GymSystem.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymSystem.DAL.Repositories.Classes
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : BaseEntities, new()
    {
        private readonly GymDbContext dbContext;
        public GenericRepository(GymDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(TEntity Item)
        {
            dbContext.Set<TEntity>().Add(Item);
        }

        public async Task<bool> Anyasync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default)
        {
            return await dbContext.Set<TEntity>().AnyAsync(predicate, ct);
        }

        public async Task<int> CompleteAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var Item = dbContext.Set<TEntity>().FirstOrDefault(m => m.Id == id);
            if (Item != null)
            {
                dbContext.Set<TEntity>().Remove(Item);
            }
        }

        public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool istracked = false, CancellationToken ct = default)
        {
            var Items = istracked ? dbContext.Set<TEntity>() : dbContext.Set<TEntity>().AsNoTracking();
            return await Items.FirstOrDefaultAsync(predicate,ct);
        }

        public async Task<IEnumerable<TEntity?>> GetAll(bool istracked, CancellationToken ct = default)
        {
            var Items = istracked ? dbContext.Set<TEntity>() : dbContext.Set<TEntity>().AsNoTracking();
            return await Items.ToListAsync();
        }

        public async Task<TEntity?> GetById(int id, CancellationToken ct = default)
        {
            var Item = await dbContext.Set<TEntity>().FirstOrDefaultAsync(m => m.Id == id);
            return Item;
        }

        public void Update(TEntity Item)
        {
            dbContext.Set<TEntity>().Update(Item);
            
        }

    }
}
