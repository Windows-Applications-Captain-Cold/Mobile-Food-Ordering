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
        private UserManager userManager;

        public UserAuthenticateViewModel()
        {
            this.userManager = new UserManager();
        }

        public async Task<UserContentViewModel> Login(string username, string password)
        {
            var userResponseData = await this.userManager.Login(username, password);
            if (string.IsNullOrEmpty(userResponseData))
            {
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<UserContentViewModel>(userResponseData);
            }
        }
    }
}
