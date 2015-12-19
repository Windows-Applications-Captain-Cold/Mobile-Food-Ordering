using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Teamer.Models;
using Teamer.Repository;
using Windows.Web.Http;

namespace Teamer.Managers
{
    public class UserManager: IManager
    {
        private const string LoginEndpoint = "http://eatfast.herokuapp.com/api/login";
        private const string RegisterEndpoint = "http://eatfast.herokuapp.com/api/login";

        private HttpClient httpClient;

        public UserManager()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<string> Login(string username, string password)
        {
            return await BasePostRequest(username, password, LoginEndpoint);
        }

        public async Task<string> SignUp(string username, string password)
        {
            return await BasePostRequest(username, password, RegisterEndpoint);
        }

        private async Task<string> BasePostRequest(string username, string password, string endpoint)
        {
            UserAuthenticateModel loginModel = new UserAuthenticateModel()
            {
                Email = username,
                Password = password
            };

            HttpStringContent jsonLoginData = new HttpStringContent(JsonConvert.SerializeObject(loginModel));
            jsonLoginData.Headers.ContentType = new Windows.Web.Http.Headers.HttpMediaTypeHeaderValue("application/json");
            var response = await this.httpClient.PostAsync(new Uri(endpoint), jsonLoginData);
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }
            else
            {
                return response.Content.ToString();
            }
        }
    }
}
