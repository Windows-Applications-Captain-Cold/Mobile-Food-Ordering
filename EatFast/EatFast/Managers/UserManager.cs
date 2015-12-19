using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Teamer.Models;
using Teamer.Repository;
using Windows.Web.Http;

namespace Teamer.Managers
{
    class UserManager: IManager
    {
        private HttpClient httpClient;

        public IRepository<User> Repository { get; set; }

        public async Task<string> Login(string url)
        {
            var response = await this.httpClient.GetAsync(new Uri(url));
            if (response.IsSuccessStatusCode)
            {
                var userData = await response.Content.ReadAsStringAsync();

                var User = JsonConvert.DeserializeObject<User>(userData);
            }

            

            return result;
        }
    }
}
