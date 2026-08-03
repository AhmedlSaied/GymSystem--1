using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymSystem.DAL.Entities;

namespace GymSystem.DAL.Repositories.Interfaces
{
    public  interface IMemberRepository
    {
        Task<IEnumerable<Member?>> GetAll(bool istracked, CancellationToken ct = default);
        Task<Member?> GetById(int id, CancellationToken ct = default);
        void Add(Member member);
        void Update(Member member);
        void Delete(int id);
        Task<int> CompleteAsync();
    }
}
