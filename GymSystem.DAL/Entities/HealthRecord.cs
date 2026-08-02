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
        public decimal height { get; set; }
        public decimal weight { get; set; }

        [Required,MaxLength(5)]
        public decimal bloodtype { get; set; }

        [MaxLength(500)]
        public string? notes { get; set; }

        public Member Member  { get; set; } = null!;

        public int memberid { get; set; }


    }
}
