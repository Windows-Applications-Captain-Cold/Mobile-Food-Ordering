namespace Teamer.Notifications
{
    using Windows.UI.Notifications;
    using NotificationsExtensions.Toasts;
    public class Notifier : INotifier
    {
        private ToastNotification ConstructToast(string title, string content)
        {
            ToastVisual visual = new ToastVisual()
            {
                TitleText = new ToastText()
                {
                    Text = title
                },

                BodyTextLine1 = new ToastText()
                {
                    Text = content
                },
            };

            var toastContent = new ToastContent()
            {
                Visual = visual,
            };

            return new ToastNotification(toastContent.GetXml());
        }

        public void Notify(string title, string message)
        {
            var toastNotification = this.ConstructToast(title, message);
            ToastNotificationManager.CreateToastNotifier().Show(toastNotification);
        }
    }
}
