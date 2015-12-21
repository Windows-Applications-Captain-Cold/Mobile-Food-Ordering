namespace Teamer.ViewModels
{
    public class ProjectViewModel : IOrganization
    {
        public ProjectViewModel(string organization, string projectName, string projectDescription)
        {
            this.Organization = organization;
            this.Name = projectName;
            this.Description = projectDescription;
        }

        public ProjectViewModel() { }

        public string Organization { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
