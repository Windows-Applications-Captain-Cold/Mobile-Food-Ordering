using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamer.Models;
using Teamer.Repository;
using Windows.Web.Http;

namespace Teamer.Repository
{
    class UsersRepository : IRepository<User>
    {
        public HttpClient HttpClient
        {
            get
            {
                return this.HttpClient;
            }

            set
            {
                this.HttpClient = value;
            }
        }

        public ICollection DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection GetAsync(string url)
        {
            throw new NotImplementedException();
        }

        public ICollection GetByIdAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection PostAsyng()
        {
            throw new NotImplementedException();
        }

        public ICollection PutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
