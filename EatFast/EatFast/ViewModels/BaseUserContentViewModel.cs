using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamer.Models;

namespace Teamer.ViewModels
{
    public class BaseUserContentViewModel
    {
        public string Name { get; set; }

        public string Organisation { get; set; }

        public ICollection<Project> Projects { get; set; }

        public string Team { get; set; }
    }
}
