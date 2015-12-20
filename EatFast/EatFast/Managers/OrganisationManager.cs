using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Web.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http.Filters;

namespace Teamer.Managers
{
    public class OrganisationManager
    {
        private const string BaseAddress = "http://127.0.0.1:3000/";
        private const string OrganisationDetailsEndPoint = "api/organisations/";
        private HttpClient httpClient;

        public OrganisationManager()
        {
            var httpBaseFilter = new HttpBaseProtocolFilter
            {
                AllowUI = false
            };
            this.httpClient = new HttpClient(httpBaseFilter);
        }

        public async Task<string> GetDetailsAsync(string organisationName)
        {
            var result = await this.httpClient.GetAsync(
                new Uri(
                    BaseAddress + 
                    OrganisationDetailsEndPoint +
                    organisationName));

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
