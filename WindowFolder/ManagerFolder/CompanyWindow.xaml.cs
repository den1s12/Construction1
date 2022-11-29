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
    /// Логика взаимодействия для CompanyWindow.xaml
    /// </summary>
    public partial class CompanyWindow : Window
    {
        SqlConnection sqlConnection =
           new SqlConnection(@"Data Source=HOME-PC\SQLEXPRESS;
                Initial Catalog=user84;
                Integrated Security=True");
        DGClass dGClass;
        public CompanyWindow()
        {
            InitializeComponent();
            dGClass = new DGClass(CompanyDG);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dGClass.LoadDg("Select * FROM dbo.[Companies]");
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddCompanyWindow().ShowDialog();
            dGClass.LoadDg("Select * From dbo.[Companies]");
            Close();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            new EditCompanyWindow().ShowDialog();
            dGClass.LoadDg("Select * From dbo.[Companies]");
            Close();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            dGClass.LoadDg("SELECT * FROM dbo.[Companies] " +
            $"Where LoginUser Like '%{SearchTb.Text}%'");
        }

        private void CompanyDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CompanyDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Вы не выбрали строку");
            }
            else
            {
                VariableClass.IdCompany = dGClass.SelectId();
                try
                {
                    new EditCompanyWindow().ShowDialog();
                    dGClass.LoadDg("Select * From dbo.[Companies]");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
