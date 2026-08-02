using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymSystem.DAL.Contexts;
using GymSystem.DAL.Entities;
using GymSystem.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymSystem.DAL.Repositories.Classes
{
    public class PlanRepository : IPlanRepository
    {
        private GymDbContext dbContext;

        public PlanRepository()
        {
            dbContext = new GymDbContext();
        }

        public void Add(Plan plan)
        {
            dbContext.Plans.Add(plan);
        }

        public async Task<int> CompleteAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
           var Product= dbContext.Plans.FirstOrDefault(p=>p.Id==id);
            if(Product!=null)
            {
                dbContext.Plans.Remove(Product);
            }
        }

        public async Task<IEnumerable<Plan>> GetAll()
        {
           return await dbContext.Plans.ToListAsync();
        }

        public async Task<Plan?> GetById(int id)
        {
            return await dbContext.Plans.FirstOrDefaultAsync(p => p.Id == id);
         }

        public void Update(Plan plan)
        {
            dbContext.Plans.Update(plan);
        }
    }
}
