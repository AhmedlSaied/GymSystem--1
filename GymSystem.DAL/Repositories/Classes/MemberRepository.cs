using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymSystem.DAL.Contexts;
using GymSystem.DAL.Entities;
using GymSystem.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace GymSystem.DAL.Repositories.Classes
{
    public class MemberRepository : IMemberRepository
    {
        private readonly GymDbContext dbContext;
        public MemberRepository(GymDbContext dbContext) 
        {
                  this.dbContext = dbContext;
        }
        public void Add(Member member)
        {
            dbContext.Members.Add(member);
        }

        public async Task<int> CompleteAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var member = dbContext.Members.FirstOrDefault(m => m.Id == id);
            if (member != null)
            {
                dbContext.Members.Remove(member);
            }
        }

        public async Task<IEnumerable<Member?>> GetAll(bool istracked, CancellationToken ct = default)
        {
            var members  = istracked ? dbContext.Members.AsTracking() : dbContext.Members.AsNoTracking();
            return await members.ToListAsync();
        }

        public async Task<Member?> GetById(int id, CancellationToken ct = default)
        {
            var member= await dbContext.Members.FirstOrDefaultAsync(m => m.Id == id);
            return member;
        }

        public void Update(Member member)
        {
            dbContext.Members.Update(member);
        }
    }
}
