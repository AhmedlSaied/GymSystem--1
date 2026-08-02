using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.DAL.Entities
{
    public class MemberShip:BaseEntities
    {
        public Member Member { get; set; } = null!;

        public int MemberId { get; set; }

        public Plan plan { get; set; } = null!;

        public int planId { get; set; }

        public DateTime EndDate {  get; set; }
        [NotMapped]
        public string status => EndDate > DateTime.Now ? "active" : "Expired";
        [NotMapped]
        public bool isactive => EndDate > DateTime.Now;
    }
}
