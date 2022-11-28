using Construction.ClassFolder;
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

namespace Construction.WindowFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        DGClass dGClass;
        public AdminWindow()
        {
            InitializeComponent();
            dGClass = new DGClass(UserDG);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dGClass.LoadDg("Select * FROM dbo.[User]");
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            dGClass.LoadDg("SELECT * FROM dbo.[User] " +
               $"Where LoginUser Like '%{SearchTb.Text}%'");
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            new AddUserWindow().ShowDialog();
            dGClass.LoadDg("Select * From dbo.[User]");
            //Close();
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            new EditUserWindow().ShowDialog();
            dGClass.LoadDg("Select * From dbo.[User]");
            //Close();
        }

        private void UserDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (UserDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Вы не выбрали строку");
            }
            else
            {
                VariableClass.IdUser = dGClass.SelectId();
                try
                {
                    new EditUserWindow().ShowDialog();
                    dGClass.LoadDg("Select * From dbo.[User]");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void ChangeUser_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }
    }
}
