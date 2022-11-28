using Construction.ClassFolder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        CBClass cB;
        SqlConnection sqlConnection =
        new SqlConnection(@"Data Source=HOME-PC\SQLEXPRESS;
                Initial Catalog=user84;
                Integrated Security=True");
        SqlCommand SqlCommand;

        public AddUserWindow()
        {
            InitializeComponent();
            cB = new CBClass();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string pass = PasswordTb.Text;
            string zagl = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string mal = "qwertyuiopasdfghjklzxcvbnm";
            

            if (string.IsNullOrWhiteSpace(LoginTb.Text))
            {
                MBClass.ErrorMB("Вы не ввели логин");
                LoginTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PasswordTb.Text))
            {
                MBClass.ErrorMB("Вы не ввели пароль");
                PasswordTb.Focus();
            }
            else if (zagl.IndexOfAny(pass.ToCharArray()) == -1)
            {
                MBClass.ErrorMB("Пароль должен содержать заглавную букву");
                PasswordTb.Focus();
            }
            else if (mal.IndexOfAny(pass.ToCharArray()) == -1)
            {
                MBClass.ErrorMB("Пароль должен содержать маленькую букву");
                PasswordTb.Focus();
            }
            

            else if (RoleCb.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Не выбрана роль");
                RoleCb.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand = new SqlCommand("Insert Into dbo.[User] " +
                        "(LoginUser, PasswordUser, IDRole) " +
                        $"Values ('{LoginTb.Text}'," +
                        $"'{PasswordTb.Text}'," +
                        $"'{RoleCb.SelectedValue.ToString()}')",
                        sqlConnection);
                    SqlCommand.ExecuteNonQuery();
                    MBClass.InformationMB($"Пользователь {LoginTb.Text} " +
                        $"успешно добавлен");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new AdminWindow().Show();
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cB.RoleCBLoad(RoleCb);
        }
    }
}
