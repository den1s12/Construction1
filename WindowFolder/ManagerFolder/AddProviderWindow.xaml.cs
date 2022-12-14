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
    /// Логика взаимодействия для AddProviderWindow.xaml
    /// </summary>
    public partial class AddProviderWindow : Window
    {
        CBClass cB;
        SqlConnection sqlConnection =
        new SqlConnection(@"Data Source=HOME-PC\SQLEXPRESS;
                Initial Catalog=user84;
                Integrated Security=True");
        SqlCommand SqlCommand;
        public AddProviderWindow()
        {
            InitializeComponent();
            cB = new CBClass();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CBCompany.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Не выбрана компания");
                CBCompany.Focus();
            }

            else
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand = new SqlCommand("Insert Into dbo.[SuppliedRecources] " +
                        "(NameResource, IdCompany) " +
                        $"Values ('{NameResource.Text}'," +                     
                        $"'{CBCompany.SelectedValue.ToString()}')",
                        sqlConnection);
                    SqlCommand.ExecuteNonQuery();
                    MBClass.InformationMB($"Ресурс {NameResource.Text} " +
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
            new ProviderWindow().Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cB.CompanyCBLoad(CBCompany);
        }
    }
}
