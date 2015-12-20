using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamer.ViewModels
{
    public class TaskViewModel : IOrganization
    {
        public string Organization { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
     
        
        public TaskViewModel(string organization, string taskName, string description)
        {
            this.Organization = organization;
            this.TaskName = taskName;
            this.Description = description;
        }  
    }
}
