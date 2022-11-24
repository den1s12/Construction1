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
    /// Логика взаимодействия для EditProviderWindow.xaml
    /// </summary>
    public partial class EditProviderWindow : Window
    {
        CBClass cB;
        SqlConnection sqlConnection =
           new SqlConnection(@"Data Source=HOME-PC\SQLEXPRESS;
                Initial Catalog=user84;
                Integrated Security=True");
        SqlCommand SqlCommand;
        SqlDataReader dataReader;
        public EditProviderWindow()
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
                    "dbo.[SuppliedRecources]" +
                    $"Set NameResource ='{NameResource.Text}'," +
                    $"IdSuppliedResource ='{SuppliedResourceCB.SelectedValue.ToString()}', " +
                    $"Where IdCompany ='{VariableClass.IdCompany}'",
                    sqlConnection);
                SqlCommand.ExecuteNonQuery();
                MBClass.InformationMB($"Данные  поставщика" +
                    $"{NameResource.Text}" +
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

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cB.ResourceNameCBLoad(SuppliedResourceCB);
           
            try
            {
                sqlConnection.Open();
                SqlCommand = new SqlCommand("Select * from dbo.[SuppliedRecources]" +
                    $"Where IdCompany = '{VariableClass.IdCompany}'",
                    sqlConnection);
                dataReader = SqlCommand.ExecuteReader();
                dataReader.Read();
                NameResource.Text = dataReader[1].ToString();
                SuppliedResourceCB.SelectedValue = dataReader[9].ToString();
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
