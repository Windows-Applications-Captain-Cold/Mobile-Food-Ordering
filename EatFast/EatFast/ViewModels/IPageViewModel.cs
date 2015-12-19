namespace Teamer.ViewModels
{
    public interface IPageViewModel : IContentViewModel
    {
        string Title { get; set; }

        IContentViewModel ContentViewModel { get; set; }
    }
}
