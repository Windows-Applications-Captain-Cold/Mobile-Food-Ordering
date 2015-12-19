namespace Teamer.Managers
{
    using Newtonsoft.Json;
    using System;
    using System.Threading.Tasks;
    using Teamer.Models;
    using Windows.Web.Http;
    using Windows.Web.Http.Filters;
    using Windows.Web.Http.Headers;

    public class UserManager: IUserManager
    {
        private const string LoginEndpoint = "http://127.0.0.1:3000/api/login";
        private const string RegisterEndpoint = "http://127.0.0.1:3000/api/signup";

        private HttpClient httpClient;

        public UserManager()
        {
            //var baseFilter = new HttpBaseProtocolFilter();
            //baseFilter.IgnorableServerCertificateErrors.Add(Windows.Security.Cryptography.Certificates.ChainValidationResult.InvalidCertificateAuthorityPolicy);
            var httpBaseFilter = new HttpBaseProtocolFilter
            {
                AllowUI = false
            };
            this.httpClient = new HttpClient(httpBaseFilter);
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
            return await this.httpClient.PostAsync(new Uri(endpoint), jsonAuthData);
        }
    }
}
