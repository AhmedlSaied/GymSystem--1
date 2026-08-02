using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.DAL.Entities
{
    public class Category :BaseEntities
    {
        public string CategoryName { get; set; } = null!;

        public ICollection<Session> sessions { get; set; } = new HashSet<Session>();
    }
}
