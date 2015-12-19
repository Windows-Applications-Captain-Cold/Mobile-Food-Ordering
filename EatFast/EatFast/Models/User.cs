using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamer.Models
{
    public class User
    {
        public string Name { get; set; }

        public string Organisation { get; set; }

        public string Email { get; set; }

        public ICollection<Project> Projects { get; set; }

        public string Team { get; set; }
    }
}
