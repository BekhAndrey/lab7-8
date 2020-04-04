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
    /// Логика взаимодействия для DataGrid.xaml
    /// </summary>
    public partial class DataGrid : Window
    {
        private readonly string Path = $"{Environment.CurrentDirectory}\\TodoDataList.json";
        private BindingList<TodoModel> TodoModelList;
        private JsonSerializer jsonSerializer;
        public DataGrid()
        {
            InitializeComponent();
            jsonSerializer = new JsonSerializer(Path);
            try
            {
                TodoModelList = jsonSerializer.Deserialize();
                ListView.Items.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            this.DataContext = TodoModelList;
            TodoModelList.ListChanged += TodoModelList_ListChanged;

        }
        private void ListWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void TodoModelList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    jsonSerializer.Serialize(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!Name.Text.Trim().Equals(string.Empty) && !Description.Text.Trim().Equals(string.Empty)&&!Status.Text.Trim().Equals(string.Empty)&& !Priority.Text.Trim().Equals(string.Empty))
            {
                TodoModelList.Add(new TodoModel() { Status = Status.Text, Priority = Priority.Text, Name = Name.Text, Description = Description.Text });
            }
            Name.Text = "";
            Description.Text = "";
            Status.Text = "";
            Priority.Text = "";
            ListView.Items.Refresh();
        }

        private void Delete_click(object sender, RoutedEventArgs e)
        {
                if (ListView.SelectedItem != null)
                {
                    MessageBoxResult del = MessageBox.Show("Delete this item?", "Delete?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                    if (del == MessageBoxResult.Yes)
                    {
                        TodoModelList.Remove(ListView.SelectedItem as TodoModel);
                    }
                    ListView.Items.Refresh();
                }
            }

        private void Edit_click(object sender, RoutedEventArgs e)
        {
                if (ListView.SelectedItem != null)
                {
                    EditWindow editWindow = new EditWindow(ListView.SelectedItem as TodoModel);
                    editWindow.Owner = this;
                    editWindow.ShowDialog();
                }
        }
    }
}
