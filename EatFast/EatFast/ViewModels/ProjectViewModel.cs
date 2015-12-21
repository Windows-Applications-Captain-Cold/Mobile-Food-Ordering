using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Teamer.Managers;

namespace Teamer.ViewModels
{
    public class ProjectViewModel : ViewModelBase
    {
        private ProjectManager projectManager;

        public ProjectViewModel(string organization, string projectName, string projectDescription)
        {
            this.Organization = organization;
            this.Name = projectName;
            this.Description = projectDescription;
            this.projectManager = new ProjectManager();
        }

        public ProjectViewModel()
        {
            this.projectManager = new ProjectManager();
        }

        public string Organization { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        internal async Task<bool> GetDetailsAsync(string projectName)
        {
            var projectResponse = await this.projectManager.GetDetailsAsync(projectName);
            if (string.IsNullOrEmpty(projectResponse))
            {
                return false;
            }

            var project = JsonConvert.DeserializeObject<ProjectViewModel>(projectResponse);
            this.Organization = project.Organization;
            RaisePropertyChanged("Organization");
            this.Name = project.Name;
            RaisePropertyChanged("Name");
            this.Description = project.Description;
            RaisePropertyChanged("Description");

            return true;
        }
    }
}
