using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Afleveringsopgaven
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            idBox.SetBinding(TextBox.TextProperty, new Binding(nameof(User.ID)));
            nameBox.SetBinding(TextBox.TextProperty, new Binding(nameof(User.Name)));
            ageBox.SetBinding(TextBox.TextProperty, new Binding(nameof(User.Age)));
            scoreBox.SetBinding(TextBox.TextProperty, new Binding(nameof(User.Score)));

        }

        private void MenuItem_Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;

                using (var file = new StreamReader(filename))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        User p = new User(line);
                        UserList.Items.Add(p);
                    }
                }
                ListCount.Content = UserList.Items.Count;
                LastUpdate.Content = $"Last update: {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}";
            }
        }
        
        private void PeopleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserList.SelectedItem is User)
            {
                idBox.DataContext = UserList.SelectedItem;
                nameBox.DataContext = UserList.SelectedItem;
                ageBox.DataContext = UserList.SelectedItem;
                scoreBox.DataContext = UserList.SelectedItem;
            }
        }
    }
}
