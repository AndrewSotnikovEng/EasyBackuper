using BackupTaskManager.Commands;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupTaskManager.ViewModels
{
    class TaskItemWindowViewModel : IDataErrorInfo
    {

        public string Name { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }

        public ReccurrenceEnum SelectedReccurrecne { get; set; }

        TaskItemModel sourceTaskItem;

        public RelayCommand CommitTaskItemCmd { get; }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        { 
            get
            {
                string error = String.Empty;

                switch (columnName)
                {
                    case "Name":
                        if (String.IsNullOrEmpty(Name)) error = "Empty Name";
                        break;
                    case "Source":
                        if (!File.Exists(Source) && !Directory.Exists(Source)) error = "Source not exist";
                        break;
                    case "Destination":
                        if (!File.Exists(Destination) && !Directory.Exists(Destination)) error = "Destination not exist";
                        break;
                }

                return error;

            }
        
        }

        public TaskItemWindowViewModel()
        {
            CommitTaskItemCmd = new RelayCommand(o => { CommitTaskInAddMode(); });
        }

        public TaskItemWindowViewModel(TaskItemModel selectedItem)
        {
            Name = selectedItem.Name;
            Source = selectedItem.Source;
            Destination = selectedItem.Destination;

            sourceTaskItem = new TaskItemModel(Name, Source, Destination, ReccurrenceEnum.Hourly);

            CommitTaskItemCmd = new RelayCommand(o => { CommitTaskInEditMode(); });
        }

        private void CommitTaskInEditMode()
        {
            TaskItemModel taskItem = new TaskItemModel(Name, Source, Destination, ReccurrenceEnum.Hourly);
            TaskItemModel[] taskItems = { sourceTaskItem, taskItem };
            MessengerStatic.NotifyTaskWindowInEditModeClosed(taskItems);
        }

        public void CommitTaskInAddMode()
        {

            TaskItemModel taskItem = new TaskItemModel(Name, Source, Destination, ReccurrenceEnum.Hourly);
            MessengerStatic.NotifyTaskWindowInAddModelClosed(taskItem);
        }

    }
}
