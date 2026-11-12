using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GymSystem.DAL.Entities;

namespace GymSystem.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity: BaseEntities , new()
    {
        Task<IEnumerable<TEntity?>> GetAll(bool istracked, CancellationToken ct = default);
        Task<TEntity?> GetById(int id, CancellationToken ct = default);
        void Add(TEntity Item);
        void Update(TEntity Item);
        void Delete(int id);
        Task<int> CompleteAsync();

        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity,bool>> predicate,bool istracked=false,CancellationToken ct=default);
        Task<bool> Anyasync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default);

    }
}
