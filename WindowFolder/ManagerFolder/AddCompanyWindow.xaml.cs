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
    /// Логика взаимодействия для AddCompanyWindow.xaml
    /// </summary>
    public partial class AddCompanyWindow : Window
    {
        CBClass cB;
        SqlConnection sqlConnection =
        new SqlConnection(@"Data Source=HOME-PC\SQLEXPRESS;
                Initial Catalog=user84;
                Integrated Security=True");
        SqlCommand SqlCommand;
        public AddCompanyWindow()
        {
            InitializeComponent();
            cB = new CBClass();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cB.StatusCBLoad(CBStatus);
            cB.DirectorCBLoad(CBDirector);
            cB.ResponsibleCBLoad(CBResponsible);
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new CompanyWindow().Show();
            this.Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CBStatus.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Не выбрана должность");
                CBStatus.Focus();
            }
            else if (CBDirector.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Не выбран директор");
                CBDirector.Focus();
            }
            else if (CBResponsible.SelectedIndex == -1)
            {
                MBClass.ErrorMB("Не выбран директор");
                CBResponsible.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand = new SqlCommand("Insert Into dbo.[Companies] " +
                        "(FullNameCompany, ShortNameCompany, IdDirector, " +
                        "IdResponsible, DescriptionCompany, IdLegalAdress, " +
                        "INN, OGRN, IdStatus) " +
                        $"Values ('{FullNameCompany.Text}'," +
                        $"'{ShortNameCompany.Text}'," +
                        $"'{CBDirector.SelectedValue.ToString()}'," +
                        $"'{CBResponsible.SelectedValue.ToString()}'," +
                        $"'{DescriptionCompany.Text}'," +
                        $"'{IdLegalAdress.Text}'," +
                        $"'{INN.Text}'," +
                        $"'{OGRN.Text}'," +
                        $"'{CBStatus.SelectedValue.ToString()}')",
                        sqlConnection);
                    SqlCommand.ExecuteNonQuery();
                    MBClass.InformationMB($"Компания {FullNameCompany.Text} " +
                        $"успешно добавлена");
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
}
