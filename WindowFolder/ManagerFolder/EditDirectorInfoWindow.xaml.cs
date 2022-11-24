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
    /// Логика взаимодействия для EditDirectorInfoWindow.xaml
    /// </summary>
    public partial class EditDirectorInfoWindow : Window
    {
        SqlConnection sqlConnection =
           new SqlConnection(@"Data Source=HOME-PC\SQLEXPRESS;
                Initial Catalog=user84;
                Integrated Security=True");
        SqlCommand SqlCommand;
        SqlDataReader dataReader;
        public EditDirectorInfoWindow()
        {
            InitializeComponent();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand =
                    new SqlCommand("Update " +
                    "dbo.[Director]" +
                    $"Set LastNameDirector ='{LastNameDirector.Text}'," +
                    $"FirstNameDirector ='{FirstNameDirector.Text}'," +
                    $"MiddleNameDirector ='{MiddleNameDirector.Text}'," +
                    $"PhoneNumberDirector ='{PhoneNumberDirector.Text}', " +
                    $"EmailDirector ='{EmailDirector.Text}' " +
                    $"Where IdDirector ='{VariableClass.IdDirector}'",
                    sqlConnection);
                SqlCommand.ExecuteNonQuery();
                MBClass.InformationMB($"Данные компании " +
                    $"{LastNameDirector.Text}" +
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
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand = new SqlCommand("Select * from dbo.[Director]" +
                    $"Where IdDirector = '{VariableClass.IdDirector}'",
                    sqlConnection);
                dataReader = SqlCommand.ExecuteReader();
                dataReader.Read();
                LastNameDirector.Text = dataReader[1].ToString();
                FirstNameDirector.Text = dataReader[2].ToString();
                MiddleNameDirector.Text = dataReader[3].ToString();
                PhoneNumberDirector.Text = dataReader[4].ToString();
                EmailDirector.Text = dataReader[5].ToString();
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
