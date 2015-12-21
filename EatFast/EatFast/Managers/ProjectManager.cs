namespace Teamer.Managers
{
    using System;
    using System.Threading.Tasks;
    using Windows.Web.Http;
    using Windows.Web.Http.Filters;
    public class ProjectManager
    {
        private const string BaseAddress = "http://127.0.0.1:3000/";
        private const string ProjectDetailsEndPoint = "api/organisations/";
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
    }
}