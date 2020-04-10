using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Globalization;
using System.Threading;
using Laba7_8.Models;
using Laba7_8.Services;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace Laba7_8
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        ObservableCollection<TodoModel> collection;
        //TodoModel newmodel;
        private DateTime TempDate;
        private string TempStatus;
        private string TempPriority;
        private string TempName;
        private string TempDescription;
        public EditWindow(TodoModel item, ObservableCollection<TodoModel> col)
        {
            InitializeComponent();
            collection = col;
            DataContext = item;
            TempDate = item.CreationDate;
            TempStatus = item.Status;
            TempPriority = item.Priority;
            TempName = item.Name;
            TempDescription = item.Description;
            collection.Remove(item);
        }

        private void SaveEdit_click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            collection.Add(new TodoModel(){CreationDate=TempDate, Status=Status.Text, Priority=Priority.Text,Name=Name.Text,Description=Description.Text });
            Close();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            bool result = DialogResult ?? false;
            if (!result)
            {
                collection.Add(new TodoModel() { CreationDate = TempDate, Status = TempStatus, Priority = TempPriority, Name = TempName, Description = TempDescription });
            }
        }
    }
}
