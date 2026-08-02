using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.DAL.Entities
{
    public class Plan
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
