using BackupTaskManager.Commands;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupTaskManager.ViewModels
{
    class TaskItemWindowViewModel
    {

        public string Name { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }

        public TaskItemModel.ReccurrenceEnum SelectedReccurrecne { get; set; }

        TaskItemModel sourceTaskItem;

        public RelayCommand CommitTaskItemCmd { get; }
        public TaskItemWindowViewModel()
        {
            CommitTaskItemCmd = new RelayCommand(o => { CommitTaskInAddMode(); });
        }

        public TaskItemWindowViewModel(TaskItemModel selectedItem)
        {
            Name = selectedItem.Name;
            Source = selectedItem.Source;
            Destination = selectedItem.Destination;

            sourceTaskItem = new TaskItemModel(Name, Source, Destination, TaskItemModel.ReccurrenceEnum.Hourly);

            CommitTaskItemCmd = new RelayCommand(o => { CommitTaskInEditMode(); });
        }

        private void CommitTaskInEditMode()
        {
            TaskItemModel taskItem = new TaskItemModel(Name, Source, Destination, TaskItemModel.ReccurrenceEnum.Hourly);
            TaskItemModel[] taskItems = { sourceTaskItem, taskItem };
            MessengerStatic.NotifyTaskWindowInEditModeClosed(taskItems);
        }

        public void CommitTaskInAddMode()
        {

            TaskItemModel taskItem = new TaskItemModel(Name, Source, Destination, TaskItemModel.ReccurrenceEnum.Hourly);
            MessengerStatic.NotifyTaskWindowInAddModelClosed(taskItem);
        }

    }
}
