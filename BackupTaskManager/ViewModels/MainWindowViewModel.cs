using BackupTaskManager.Commands;
using BackupTaskManager.ViewModels;
using DataLayer;
using DataLayer.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace BackupTaskManager
{
    public class MainWindowViewModel : ViewModelBase
    {

        TaskItemsRepository repository = new DataLayer.TaskItemsRepository();
        ICollectionView view;

        TaskItemModel selectedTaskItem;

        ObservableCollection<TaskItemModel> taskItems = new ObservableCollection<TaskItemModel>();
        private string filterWord;

        public ObservableCollection<TaskItemModel> TaskItems { get => taskItems; set 
            { 
                taskItems = value;
                OnPropertyChanged("TaskItems");
            }
        }
        public string FilterWord
        {
            get
            {
                return filterWord;
            }
            set
            {
                if (value != filterWord)
                {
                    filterWord = value;
                    view.Refresh();
                    OnPropertyChanged("FilterWord");
                }
            }
        }

        public TaskItemModel SelectedTaskItem {
            get => selectedTaskItem; 
            set => selectedTaskItem = value; }

        public RelayCommand EditButtonCmd { get; set; }

        internal void Save()
        {
            repository.Models = TaskItems;
            repository.Save();
        }

        public RelayCommand DeleteButtonCmd { get; set; }
        public MainWindowViewModel()
        {
            repository.Load("repository.xml");
            TaskItems = repository.Models;
            WireFilter();

            EditButtonCmd = new RelayCommand(o => { EditCommand(); });
            DeleteButtonCmd = new RelayCommand(o => { DeleteAction(); }, DeleteBtnCanExecute );

            MessengerStatic.TaskItemWindowClosedInAddMode += MessengerStatic_TaskItemWindowClosedInAddMode;
            MessengerStatic.TaskItemWindowClosedInEditMode += MessengerStatic_TaskItemWindowClosedInEditMode;
        }

        private void MessengerStatic_TaskItemWindowClosedInEditMode(object obj)
        {
            TaskItemModel[] arr = ((TaskItemModel[])obj);

        }

        private void EditCommand()
        {
            MessengerStatic.NotifyTaskWindowOpened(SelectedTaskItem);
        }

        private bool DeleteBtnCanExecute(object arg)
        {
            bool result = (SelectedTaskItem != null) ? true : false;

            return result;
        }

        private void DeleteAction()
        {
            TaskItems.Remove(SelectedTaskItem);
        }

        private void MessengerStatic_TaskItemWindowClosedInAddMode(object obj)
        {
            TaskItems.Add((TaskItemModel)obj);
        }




        public void WireFilter()
        {
            view = CollectionViewSource.GetDefaultView(TaskItems);
            view.Filter = o => String.IsNullOrEmpty(FilterWord) ?
                    true : Regex.IsMatch(((TaskItemModel)o).Source, $"{FilterWord}", RegexOptions.IgnoreCase);
        }
    }
    
}