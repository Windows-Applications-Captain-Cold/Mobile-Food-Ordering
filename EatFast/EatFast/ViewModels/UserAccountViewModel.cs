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
        private ProjectManager projectManager;

        public UserAccountViewModel()
        {
            this.userManger = new UserManager();
            this.projectManager = new ProjectManager();
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

        internal async Task<bool> UpdateProjectStatus(string projectName, bool status)
        {
            return await this.projectManager.ToggleStatus(projectName, status);
        }
    }
}
