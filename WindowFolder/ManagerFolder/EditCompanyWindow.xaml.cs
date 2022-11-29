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
    /// Логика взаимодействия для EditCompanyWindow.xaml
    /// </summary>
    public partial class EditCompanyWindow : Window
    {
        CBClass cB;
        SqlConnection sqlConnection=
           new SqlConnection(@"Data Source=HOME-PC\SQLEXPRESS;
                Initial Catalog=user84;
                Integrated Security=True");
        SqlCommand SqlCommand;
        SqlDataReader dataReader;

        public EditCompanyWindow()
        {
            InitializeComponent();
            cB = new CBClass();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cB.ResponsibleCBLoad(CBResponsible);
            cB.StatusCBLoad(CBStatus);
            cB.DirectorCBLoad(CBDirector);
            try
            {
                sqlConnection.Open();
                SqlCommand = new SqlCommand("Select * from dbo.[Companies]" +
                    $"Where IdCompany = '{VariableClass.IdCompany}'",
                    sqlConnection);
                dataReader = SqlCommand.ExecuteReader();
                dataReader.Read();
                FullNameCompany.Text = dataReader[1].ToString();
                ShortNameCompany.Text = dataReader[2].ToString();
                CBDirector.SelectedValue = dataReader[4].ToString();
                CBResponsible.SelectedValue = dataReader[3].ToString();
                DescriptionCompany.Text = dataReader[5].ToString();
                IdLegalAdress.Text = dataReader[6].ToString();
                INN.Text = dataReader[7].ToString();
                OGRN.Text = dataReader[8].ToString();
                CBStatus.SelectedValue = dataReader[9].ToString();

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
            new CompanyWindow().Show();
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand =
                    new SqlCommand("Update " +
                    "dbo.[Companies]" + 
                    $"Set FullNameCompany ='{FullNameCompany.Text}'," +
                    $"ShortNameCompany ='{ShortNameCompany.Text}'," +
                    $"IdDirector ='{CBDirector.SelectedValue.ToString()}'," +
                    $"IdResponsible ='{CBResponsible.SelectedValue}'," +
                    $"DescriptionCompany ='{DescriptionCompany.Text}'," +
                    $"IdLegalAdress ='{IdLegalAdress.Text}', " +
                    $"INN ='{INN.Text}', " +
                    $"OGRN ='{OGRN.Text}', " +
                    $"IdStatus ='{CBStatus.SelectedValue.ToString()}' " +
                    $"Where IdCompany ='{VariableClass.IdCompany}'",
                    sqlConnection);
                SqlCommand.ExecuteNonQuery();
                MBClass.InformationMB($"Данные компании " +
                    $"{FullNameCompany.Text}" +
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
