using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.DAL.Entities
{
    public class Member:GymUser
    {
        public string photo {get; set; } = null!;

        public HealthRecord HealthRecord { get; set; } = null!;

        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

        public ICollection<MemberShip> Memberships { get; set; }= new HashSet<MemberShip>();
    }
}
