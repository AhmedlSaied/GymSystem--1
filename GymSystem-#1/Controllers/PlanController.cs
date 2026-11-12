using GymSystem.DAL.Contexts;
using GymSystem.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymSystem.DAL.Repositories.Classes;
using GymSystem.DAL.Entities;

namespace GymSystem__1.Controllers
{
    public class PlanController : Controller
    {

        private readonly IGenericRepository <Plan>planRepository;
        public PlanController(IGenericRepository<Plan> _planRepository)
        {
            planRepository = _planRepository;
        }
        public async Task <IActionResult> Index()
        {
            var plans =await planRepository.GetAll(false);
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
