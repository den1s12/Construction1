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
    /// Логика взаимодействия для EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        CBClass cB;
        SqlConnection sqlConnection =
        new SqlConnection(@"Data Source=HOME-PC\SQLEXPRESS;
                Initial Catalog=user84;
                Integrated Security=True");
        SqlCommand SqlCommand;
        SqlDataReader dataReader;

        public EditUserWindow()
        {
            InitializeComponent();
            cB = new CBClass();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand =
                    new SqlCommand("Update " +
                    "dbo.[User] " +
                    $"Set [LoginUser] ='{LoginTb.Text}'," +
                    $"[PasswordUser]='{PasswordTb.Text}'," +
                    $"IdRole='{RoleCb.SelectedValue.ToString()}' " +
                    $"Where IdUser='{VariableClass.IdUser}'",
                    sqlConnection);
                SqlCommand.ExecuteNonQuery();
                MBClass.InformationMB($"Данные пользователя " +
                    $"{LoginTb.Text} " +
                    $"успешно отредактированы");
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

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new AdminWindow().Show();
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cB.RoleCBLoad(RoleCb);
            try
            {
                sqlConnection.Open();
                SqlCommand = new SqlCommand("Select * From dbo.[User] " +
                    $"Where IdUser='{VariableClass.IdUser}'",
                    sqlConnection);
                dataReader = SqlCommand.ExecuteReader();
                dataReader.Read();
                LoginTb.Text = dataReader[1].ToString();
                PasswordTb.Text = dataReader[2].ToString();
                RoleCb.SelectedValue = dataReader[3].ToString();
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
}
