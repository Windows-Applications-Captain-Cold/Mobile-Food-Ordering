using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Teamer.Helpers;
using Teamer.Managers;
using Teamer.Models;

namespace Teamer.ViewModels
{
    public class UserAuthenticateViewModel : IContentViewModel
    {
        private IUserManager userManager;

        public UserAuthenticateViewModel()
            :this(new UserManager())
        {
            
        }

        public UserAuthenticateViewModel(IUserManager manager)
        {
            this.userManager = manager;
        }

        public async Task<UserContentViewModel> Login(string username, string password)
        {
            var userResponseData = await this.userManager.Login(username, password);
            if (string.IsNullOrEmpty(userResponseData))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<UserContentViewModel>(userResponseData);
        }

        public async Task<UserContentViewModel> Register(string username, string password)
        {
            var userResponseData = await this.userManager.Register(username, password);
            if (string.IsNullOrEmpty(userResponseData))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<UserContentViewModel>(userResponseData);
        }
    }
}
