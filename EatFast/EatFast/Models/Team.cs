using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamer.Models
{
    public class Team
    {
        public string Name { get; set; }

        public string Leader { get; set; }

        public ICollection<Project> Projects { get; set; }

        public ICollection<User> Members { get; set; }
    }
}
