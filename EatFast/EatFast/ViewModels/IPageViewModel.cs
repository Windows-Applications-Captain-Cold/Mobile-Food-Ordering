namespace Teamer.ViewModels
{
    interface IPageViewModel : IContentViewModel
    {
        string Title { get; set; }

        IContentViewModel ContentViewModel { get; set; }
    }
}
