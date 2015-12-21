namespace Teamer.Managers
{
    using System;
    using System.Threading.Tasks;
    using Windows.Web.Http;
    using Windows.Web.Http.Filters;
    public class ProjectManager
    {
        private const string BaseAddress = "http://eatfast.herokuapp.com/";
        private const string ProjectDetailsEndPoint = "api/projects/";
        private const string ProjectStatusUpdateEndPoint = "api/projects/toggle/";
        private HttpClient httpClient;

        public ProjectManager()
        {
            var httpBaseFilter = new HttpBaseProtocolFilter
            {
                AllowUI = false
            };
            this.httpClient = new HttpClient(httpBaseFilter);
        }

        public async Task<string> GetDetailsAsync(string projectName)
        {
            var result = await this.httpClient.GetAsync(
                new Uri(
                    BaseAddress +
                    ProjectDetailsEndPoint +
                    projectName));

            if (result.StatusCode == HttpStatusCode.Ok)
            {
                return result.Content.ToString();
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> ToggleStatus(string name)
        {
            var result = await this.Update(name, new HttpStringContent(""));
            if (!string.IsNullOrEmpty(result))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<string> Update(string name, IHttpContent content)
        {
            var result = await this.httpClient.PutAsync(
                new Uri(
                    BaseAddress + ProjectStatusUpdateEndPoint + name),
                content);

            if (result.StatusCode == HttpStatusCode.Ok)
            {
                return result.Content.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}