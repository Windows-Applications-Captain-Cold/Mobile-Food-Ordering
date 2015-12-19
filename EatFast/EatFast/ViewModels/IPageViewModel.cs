namespace Teamer.ViewModels
{
    interface IPageViewModel
    {
        string Title { get; set; }

        IContentViewModel ContentViewModel { get; set; }
    }
}
