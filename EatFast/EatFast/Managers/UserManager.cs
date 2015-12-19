using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamer.Models;
using Teamer.Repository;

namespace Teamer.Managers
{
    class UserManager: IManager
    {
        public IRepository<User> Repository { get; set; }

        public void GetRemoteData()
        {

        }
    }
}
