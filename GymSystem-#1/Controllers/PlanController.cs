using GymSystem.DAL.Contexts;
using GymSystem.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymSystem.DAL.Repositories.Classes;

namespace GymSystem__1.Controllers
{
    public class PlanController : Controller
    {

        private readonly IPlanRepository planRepository;
        public PlanController()
        {
            planRepository = new PlanRepository();
        }
        public async Task <IActionResult> Index()
        {
            var plans =await planRepository.GetAll();
            return View(plans);
        }

        public async Task <IActionResult> Details(int id)
        {
            var plan = await planRepository.GetById(id);
            if (plan == null)
            {
                RedirectToAction(nameof(Index));
            }
            return View(plan);
        }
    }
}
