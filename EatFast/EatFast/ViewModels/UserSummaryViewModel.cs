namespace Teamer.ViewModels
{
    using Models;
    using System.Collections.Generic;

    public class UserSummaryViewModel
    {
        public string Name { get; set; }

        public string Organisation { get; set; }

        public ICollection<Project> Projects { get; set; }

        public string Team { get; set; }

        public string MainProject { get; set; }
    }
}
