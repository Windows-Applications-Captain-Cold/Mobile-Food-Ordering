namespace Teamer.Notifications
{
    public interface INotifier
    {
        void Notify(string Title, string Message);
    }
}
