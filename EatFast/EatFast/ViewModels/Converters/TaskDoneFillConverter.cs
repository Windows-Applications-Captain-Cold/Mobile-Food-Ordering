using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Teamer.ViewModels.Converters
{
    class TaskDoneFillConverter : IValueConverter
    {
        private const string TaskDoneColor = "Green";
        private const string TaskNotDoneColor = "Red";
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var valueAsBool = (bool)value;
            if (valueAsBool == true)
            {
                return TaskDoneColor;
            }
            else
            {
                return TaskNotDoneColor;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
