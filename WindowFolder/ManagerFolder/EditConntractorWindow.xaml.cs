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
    /// Логика взаимодействия для EditConntractorWindow.xaml
    /// </summary>
    public partial class EditConntractorWindow : Window
    {
        CBClass cB;
        SqlConnection sqlConnection =
        new SqlConnection(@"Data Source=HOME-PC\SQLEXPRESS;
                Initial Catalog=user84;
                Integrated Security=True");
        SqlCommand SqlCommand;
        SqlDataReader dataReader;
        public EditConntractorWindow()
        {
            InitializeComponent();
            cB = new CBClass();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cB.CompanyCBLoad(CompanyCB);
            try
            {
                sqlConnection.Open();
                SqlCommand = new SqlCommand("Select * from dbo.[InfWorkContractor] " +
                    $"Where IdWork = '{VariableClass.IdWork}' ",
                    sqlConnection);
                dataReader = SqlCommand.ExecuteReader();
                dataReader.Read();
                NameWorkCategory.Text = dataReader[1].ToString();
                NameCity.Text = dataReader[2].ToString();
                NameStreet.Text = dataReader[4].ToString();
                House.Text = dataReader[3].ToString();
                Building.Text = dataReader[5].ToString();
                Apartment.Text = dataReader[6].ToString();
                CompanyCB.SelectedValue = dataReader[7].ToString();

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

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand =
                    new SqlCommand("Update " +
                    "dbo.[InfWorkContractor]" +
                    $"Set NameWorkCategory ='{NameWorkCategory.Text}'," +
                    $"NameCity ='{NameCity.Text}'," +
                    $"NameStreet ='{NameStreet.Text}'," +
                    $"House ='{House.Text}'," +
                    $"Building ='{Building.Text}'," +
                    $"Apartment ='{Apartment.Text}', " +
                    $"IdCompany ='{CompanyCB.SelectedValue.ToString()}' " +
                    $"Where IdWork ='{VariableClass.IdWork}'",
                    sqlConnection);
                SqlCommand.ExecuteNonQuery();
                MBClass.InformationMB($"Данные " +
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
    }
}
