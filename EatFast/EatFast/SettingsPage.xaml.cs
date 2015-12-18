using Teamer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamer
{
    public sealed partial class SettingsPage
    {
        public SettingsPage()
        {
            this.InitializeComponent();
            var settingsPanelViewModel = new SettingsPanelViewModel
            {
                options = new List<string>
                {
                    "Settings",
                    "Sync favourites",
                    "Clear local data"
                }
            };
        }
    }
}
