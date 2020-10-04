using BackupTaskManager.Commands;
using BackupTaskManager.ViewModels;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BackupTaskManager.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TaskItemWindow : Window
    {
        public TaskItemWindow()
        {
            InitializeComponent();
            DataContext = new TaskItemWindowViewModel();

        }

        public TaskItemWindow(TaskItemModel selectedItem)
        {
            InitializeComponent();
            DataContext = new TaskItemWindowViewModel(selectedItem);

        }


    }
}
