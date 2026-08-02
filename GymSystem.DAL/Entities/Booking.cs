using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.DAL.Entities
{
    public class Booking:BaseEntities
    {

        public Member Member { get; set; } = null!;
        public int MemberId { get; set; }
        public Session Session { get; set; } = null!;
        public int SessionID { get; set; }

        public bool IsAttended { get; set; }
    }
}
