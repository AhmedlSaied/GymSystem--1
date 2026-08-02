using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.DAL.Entities
{
    public class Session:BaseEntities
    {
        public string Describtion { get; set; } = null!;

        public int Capacity { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Trainer trainer { get; set; } = null!;

        public int traineriD { get; set; }

        public Category category { get; set; } = null!;

        public int categioryId { get; set; }
        public ICollection<MemberShip> memberShips { get; set; } = new HashSet<MemberShip>();
        public ICollection<Booking> bookings { get; set; } = new HashSet<Booking>();
    }
}
