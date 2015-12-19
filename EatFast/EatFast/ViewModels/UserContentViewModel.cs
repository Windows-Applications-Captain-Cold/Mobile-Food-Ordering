using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamer.ViewModels
{
    public class UserContentViewModel
    {
        public UserContentViewModel()
        {

        }

        public string Name { get; set; }

        public string Organisation { get; set; }

        public string Email { get; set; }

        public ICollection<string> Projects { get; set; }

        public string Team { get; set; }
    }
}
