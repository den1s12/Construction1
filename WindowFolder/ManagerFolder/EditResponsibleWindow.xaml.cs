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

namespace Construction.WindowFolder.ManagerFolder
{
    /// <summary>
    /// Логика взаимодействия для EditResponsibleWindow.xaml
    /// </summary>
    public partial class EditResponsibleWindow : Window
    {
        SqlConnection sqlConnection =
          new SqlConnection(@"Data Source=HOME-PC\SQLEXPRESS;
                Initial Catalog=user84;
                Integrated Security=True");
        SqlCommand SqlCommand;
        SqlDataReader dataReader;
        public EditResponsibleWindow()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand =
                    new SqlCommand("Update " +
                    "dbo.[Responsible]" +
                    $"Set[LastNameResponsible] ='{LastNameResponsible.Text}'," +
                    $"[FirstNameResponsible] ='{FirstNameResponsible.Text}'," +
                    $"[MiddleNameResponsible] ='{MiddleNameResponsible.Text}'," +
                    $"[PhoneNumberResponsible] ='{PhoneNumberResponsible.Text}', " +
                    $"[EmailResponsible] ='{EmailResponsible.Text}' " +
                    $"Where IdResponsible='{VariableClass.IdResponsible}'",
                    sqlConnection);
                SqlCommand.ExecuteNonQuery();
                MBClass.InformationMB($"Данные компании " +
                    $"{LastNameResponsible.Text}" +
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand = new SqlCommand("Select * From dbo.[Responsible]" +
                    $"Where IdResponsible='{VariableClass.IdResponsible}'",
                    sqlConnection);
                dataReader = SqlCommand.ExecuteReader();
                dataReader.Read();
                LastNameResponsible.Text = dataReader[1].ToString();
                FirstNameResponsible.Text = dataReader[2].ToString();
                MiddleNameResponsible.Text = dataReader[3].ToString();
                PhoneNumberResponsible.Text = dataReader[4].ToString();
                EmailResponsible.Text = dataReader[5].ToString();
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
