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
    /// Логика взаимодействия для AddConntractorWindow.xaml
    /// </summary>
    public partial class AddConntractorWindow : Window
    {
        CBClass cB;
        SqlConnection sqlConnection =
        new SqlConnection(@"Data Source=HOME-PC\SQLEXPRESS;
                Initial Catalog=user84;
                Integrated Security=True");
        SqlCommand SqlCommand;
        public AddConntractorWindow()
        {
            InitializeComponent();
            cB = new CBClass();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (CompanyCB.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Не выбрана компанию");
                CompanyCB.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand =
                        new SqlCommand("Insert Into " +
                        "dbo.[InfWorkContractor] " +
                        "(NameWorkCategory, NameCity, NameStreet, " +
                        "House, Building, Apartment, IdCompany)" +
                        $"Values ('{NameWorkCategory.Text}'," +
                        $"'{NameCity.Text}'," +
                        $"'{NameStreet.Text}'," +
                        $"'{House.Text}'," +
                        $"'{Building.Text}'," +
                        $"'{Apartment.Text}', " +
                        $"'{CompanyCB.SelectedValue.ToString()}')",
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

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new ConntractorsWindow().Show();
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cB.CompanyCBLoad(CompanyCB);

        }
    }
}
