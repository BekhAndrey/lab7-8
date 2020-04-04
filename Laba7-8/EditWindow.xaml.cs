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
namespace Laba7_8
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private string TempStatus;
        private string TempPriority;
        private string TempName;
        private string TempDescription;
        public EditWindow(TodoModel item)
        {
            InitializeComponent();
            DataContext = item;
            TempStatus = item.Status;
            TempPriority = item.Priority;
            TempName = item.Name;
            TempDescription = item.Description;
        }

        private void SaveEdit_click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            bool result = DialogResult ?? false;
            if (!result)
            {
                (DataContext as TodoModel).Status = TempStatus;
                (DataContext as TodoModel).Priority = TempPriority;
                (DataContext as TodoModel).Name = TempName;
                (DataContext as TodoModel).Description = TempDescription;
            }
        }
    }
}
