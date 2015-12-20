using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamer.ViewModels
{
    public class ProjectViewModel : IOrganization
    {
        public string Organization { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }


        public ProjectViewModel(string organization, string projectName, string projectDescription)
        {
            this.Organization = organization;
            this.ProjectName = projectName;
            this.ProjectDescription = projectDescription;

        }
    }
}
