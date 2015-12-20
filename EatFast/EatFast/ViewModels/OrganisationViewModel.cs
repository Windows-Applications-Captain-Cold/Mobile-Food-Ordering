namespace Teamer.ViewModels
{
    using Managers;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Teamer.Models;

    public class OrganisationViewModel : ViewModelBase
    {
        private OrganisationManager organisationManager;

        public OrganisationViewModel()
        {
            this.organisationManager = new OrganisationManager();
        }

        public string Name { get; set; }

        public Project Project { get; set; }

        public ICollection<string> Teams { get; set; }

        internal async Task<bool> GetOrganisationDetailsAsync(string organisationName)
        {
            var organisationDetails = await this.organisationManager.GetDetailsAsync(organisationName);
            if (string.IsNullOrEmpty(organisationDetails))
            {
                return false;
            }

            var Organisation = JsonConvert.DeserializeObject<OrganisationViewModel>(organisationDetails);
            this.Name = Organisation.Name;
            this.Project = Organisation.Project;
            this.Teams = Organisation.Teams;
            this.RaisePropertyChanged("Name");
            this.RaisePropertyChanged("Project");
            this.RaisePropertyChanged("Teams");
            return true;
        }
    }
}
