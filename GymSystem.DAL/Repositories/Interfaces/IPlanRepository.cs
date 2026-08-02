using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymSystem.DAL.Entities;

namespace GymSystem.DAL.Repositories.Interfaces
{
    public interface IPlanRepository
    {
        Task<IEnumerable<Plan?>> GetAll(bool istracked,CancellationToken ct=default);

        Task<Plan>GetById(int id,CancellationToken ct=default);
        //save changes
        void Add(Plan plan);

        void Update(Plan plan);

        void Delete(int id);

        Task<int> CompleteAsync();
    }
}
