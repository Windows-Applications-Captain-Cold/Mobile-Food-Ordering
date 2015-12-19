namespace Teamer.ViewModels
{
    using System.Collections.Generic;

    public class UserContentViewModel
    {
        public string Name { get; set; }

        public string Organisation { get; set; }

        public string Email { get; set; }

        public ICollection<string> Projects { get; set; }

        public string Team { get; set; }
    }
}
