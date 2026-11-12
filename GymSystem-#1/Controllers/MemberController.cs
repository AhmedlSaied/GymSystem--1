using GymSystem.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymSystem__1.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberServices memberServices;
        public MemberController(IMemberServices memberServices)
        {
            this.memberServices = memberServices;
        }
        //service get all members
        public async Task<IActionResult> Index (CancellationToken ct)
        {
            var member = await memberServices.GetallmembersAsync (ct);
            return View(member);
        }
    }
}
