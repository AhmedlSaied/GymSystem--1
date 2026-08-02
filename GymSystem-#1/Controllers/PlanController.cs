using GymSystem.DAL.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymSystem__1.Controllers
{
    public class PlanController : Controller
    {
        // 2 actions: index(allplans) details (plan details)

        private readonly GymDbContext dbcontext=new GymDbContext();
        public async Task <IActionResult> Index()
        {
            var plans =await dbcontext.Plans.ToListAsync();
            return View(plans);
        }

        public async Task <IActionResult> Details(int id)
        {
            var plan = await dbcontext.Plans.FirstOrDefaultAsync(p => p.Id == id);
            if (plan == null)
            {
                RedirectToAction(nameof(Index));
            }
            return View(plan);
        }
    }
}
