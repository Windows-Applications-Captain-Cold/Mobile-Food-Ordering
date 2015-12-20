namespace Teamer.ViewModels
{
    using Managers;
    using System;
    using System.Threading.Tasks;
    using Windows.Media.Capture;
    using Windows.UI.Xaml.Media.Imaging;
    public class UserAccountViewModel : BaseUserContentViewModel
    {
        private UserManager userManger;

        public UserAccountViewModel()
        {
            this.userManger = new UserManager();
        }

        public async Task<BitmapImage> TakePicture()
        {
            var camera = new CameraCaptureUI();
            var photo = await camera.CaptureFileAsync(CameraCaptureUIMode.Photo);
            if (photo != null)
            {
                return new BitmapImage(new Uri(photo.Path));
            }

            return null;
        }

        public async Task<bool> UploadPicture(BitmapImage image)
        {
            return true;
        }
    }
}
