using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamer.Models
{
    public class Organisation
    {
        public string Name { get; set; }

        public string Owner { get; set; }

        public Project Project { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}
