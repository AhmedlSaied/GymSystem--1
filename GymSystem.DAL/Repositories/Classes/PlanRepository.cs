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
    public class PlanRepository : GenericRepository<Plan> ,IPlanRepository
    {
        private readonly GymDbContext dbContext;

        public PlanRepository(GymDbContext _dbContext): base(_dbContext)
        {
            dbContext = _dbContext;
        }

    
    }
}
