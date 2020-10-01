using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupTaskManager.ViewModels
{
    class MessengerStatic
    {
        public static event Action<object> TaskItemWindowClosed;

        public static void NotifyTaskWindowClosed(object taskItem)
            => TaskItemWindowClosed?.Invoke(taskItem);


    }
}