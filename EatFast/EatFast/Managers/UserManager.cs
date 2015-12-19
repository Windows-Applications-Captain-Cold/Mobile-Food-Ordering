namespace Teamer.Managers
{
    using Newtonsoft.Json;
    using System;
    using System.Threading.Tasks;
    using Teamer.Models;
    using Windows.Web.Http;
    using Windows.Web.Http.Headers;

    public class UserManager: IUserManager
    {
        private const string LoginEndpoint = "http://eatfast.herokuapp.com/api/login";
        private const string RegisterEndpoint = "http://eatfast.herokuapp.com/api/signup";

        private HttpClient httpClient;

        public UserManager()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<string> Login(string username, string password)
        {
            var response = await BaseAuthenticate(username, password, LoginEndpoint);
            if (response.StatusCode == HttpStatusCode.Ok)
            {
                return response.Content.ToString();
            }
            else
            {
                return null;
            }
        }

        public async Task<string> Register(string username, string password)
        {
            var response = await BaseAuthenticate(username, password, RegisterEndpoint);
            if (response.StatusCode == HttpStatusCode.Ok)
            {
                return await Login(username, password);
            }
            else
            {
                return null;
            }
        }

        private async Task<HttpResponseMessage> BaseAuthenticate(string username, string password, string endpoint)
        {
            var authenticateModel = new UserAuthenticateModel()
            {
                Email = username,
                Password = password
            };

            var jsonData = JsonConvert.SerializeObject(authenticateModel);
            var jsonAuthData = new HttpStringContent(jsonData);
            jsonAuthData.Headers.ContentType = new HttpMediaTypeHeaderValue("application/json");
            var response = await this.httpClient.PostAsync(new Uri(endpoint), jsonAuthData);
            return response;
        }
    }
}
