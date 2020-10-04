using BackupTaskManager.View;
using BackupTaskManager.ViewModels;
using DataLayer;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BackupTaskManager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            DataContext = mainWindowViewModel;
            Closing += MainWindow_Closing;
            MessengerStatic.TaskItemWindowOpened += MessengerStatic_TaskItemWindowOpened;
        }

        private void MessengerStatic_TaskItemWindowOpened(object obj)
        {
            TaskItemModel selectedItem = (TaskItemModel)obj;
            TaskItemWindow taskItemWin = new TaskItemWindow(selectedItem);
            taskItemWin.Show();
            

        }

        //todo
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ((MainWindowViewModel)DataContext).Save();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TaskItemWindow taskItemWin = new TaskItemWindow();
            taskItemWin.Show();

        }
    }
}
