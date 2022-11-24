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

namespace Construction.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        SqlConnection sqlConnection =
            new SqlConnection(@"Data Source=HOME-PC\SQLEXPRESS;
                Initial Catalog=user84;
                Integrated Security=True");
                               
        SqlDataReader dataReader;
        SqlCommand sqlCommand;
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTb.Text))
            {
                MBClass.ErrorMB("Введите логин");
                LoginTb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PasswordTb.Password))
            {
                MBClass.ErrorMB("Введите пароль");
                PasswordTb.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("SELECT PasswordUser, IdRole " +
                        "From dbo.[User] " +
                        $"Where LoginUser='{LoginTb.Text}'", sqlConnection);
                    dataReader = sqlCommand.ExecuteReader();
                    dataReader.Read();

                    if (dataReader[0].ToString() != PasswordTb.Password)
                    {
                        MBClass.ErrorMB("Вы ввели не правильный пароль");
                        PasswordTb.Focus();
                    }
                    else
                    {
                        switch (dataReader[1].ToString())
                        {
                            case "1":
                                new AdminFolder.AdminWindow().ShowDialog();
                                break;
                            case "2":
                                new ManagerFolder.ManagerWindow().ShowDialog();
                                break;
                        }
                    }
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

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            MBClass.ExitMB();
        }
    }
}
