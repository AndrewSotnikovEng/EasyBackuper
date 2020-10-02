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

        ItemsRepository repository = new DataLayer.ItemsRepository();
        ICollectionView view;

        ItemModel selectedTaskItem;

        ObservableCollection<ItemModel> taskItems = new ObservableCollection<ItemModel>();
        private string filterWord;

        public ObservableCollection<ItemModel> TaskItems { get => taskItems; set 
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

        public ItemModel SelectedTaskItem {
            get => selectedTaskItem; 
            set => selectedTaskItem = value; }

        public RelayCommand DeleteButtonCmd { get; set; }
        public MainWindowViewModel()
        {
            repository.Load("rep.xml");
            TaskItems = repository.Models;
            WireFilter();

            DeleteButtonCmd = new RelayCommand(o => { DeleteAction(); }, DeleteBtnCanExecute );

            MessengerStatic.TaskItemWindowClosed += MessengerStatic_TaskItemWindowClosed;
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

        private void MessengerStatic_TaskItemWindowClosed(object obj)
        {
            TaskItems.Add((ItemModel)obj);
        }




        public void WireFilter()
        {
            view = CollectionViewSource.GetDefaultView(TaskItems);
            view.Filter = o => String.IsNullOrEmpty(FilterWord) ?
                    true : Regex.IsMatch(((ItemModel)o).Source, $"{FilterWord}", RegexOptions.IgnoreCase);
        }
    }
    
}