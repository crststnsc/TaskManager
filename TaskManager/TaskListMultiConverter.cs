using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TaskManager.Models;

namespace TaskManager
{
    internal class TaskListMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            List<object> items = new List<object>();
            items.AddRange((IEnumerable<object>)(values[0] as IEnumerable<Models.Task>));
            items.AddRange(values[1] as IEnumerable<ToDoList>);
            return items;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}