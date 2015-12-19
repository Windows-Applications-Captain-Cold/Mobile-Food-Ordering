using System;

namespace Teamer.ViewModels
{
    public class PageViewModel : IPageViewModel
    {
        public IContentViewModel ContentViewModel
        {
            get
            {
                return this.ContentViewModel;
            }

            set
            {
                this.ContentViewModel = value;
            }
        }

        public string Title
        {
            get
            {
                return this.Title;
            }

            set
            {
                this.Title = value;
            }
        }
    }
}
