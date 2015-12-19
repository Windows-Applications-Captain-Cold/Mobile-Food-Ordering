using System;

namespace Teamer.ViewModels
{
    public class PageViewModel : IPageViewModel
    {
        public IPageViewModel ContentViewModel
        {
            get
            {
                return this.ContentViewModel;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string mainMenuGridMargin { get; set; }

        public string Title
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
