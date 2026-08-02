using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.DAL.Entities
{
    public class HealthRecord:BaseEntities

    {
        public decimal Height { get; set; }
        public decimal Weight { get; set; }

        [Required,MaxLength(5)]
        public decimal BloodType { get; set; }

        [MaxLength(500)]
        public string? Note { get; set; }

        public Member Member  { get; set; } = null!;

        public int MemberId { get; set; }


    }
}
