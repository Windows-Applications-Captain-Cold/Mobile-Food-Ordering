namespace Teamer.ViewModels
{
    using Managers;
    using System;
    using System.Linq;
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

        internal async Task<bool> UpdateProjectStatus(string projectName)
        {
            var status = await this.projectManager.ToggleStatus(projectName);
            var project = this.Projects.Where(p => p.Name == projectName)
                .FirstOrDefault();


            this.Projects.Where(p => p.Name == project.Name)
                .FirstOrDefault()
                .Done = status;

            RaisePropertyChanged("Projects");
            RaisePropertyChanged("Done");
            return status;
        }
    }
}
