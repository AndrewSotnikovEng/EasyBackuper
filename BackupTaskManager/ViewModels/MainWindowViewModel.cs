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

        public MainWindowViewModel()
        {
            repository.Load("rep.xml");
            TaskItems = repository.Models;
            WireFilter();

            MessengerStatic.TaskItemWindowClosed += MessengerStatic_TaskItemWindowClosed;
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